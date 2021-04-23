using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VimaruAsset.Data;
using VimaruAsset.Models;

namespace VimaruAsset.Controllers
{
     [Authorize]  public class AddAssetsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
       public AddAssetsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }


        // GET: AddAssets
         [Authorize] 
        public async Task<IActionResult> Index()
        {
            Privacy prv = new Privacy();
            if (DateTime.Now > prv.DateEnd2)
            {
                return NotFound();
            }
            return View(await _context.Assets.ToListAsync());
        }
        [Authorize]
        private bool AssetsExists(Guid id)
        {
            return _context.Assets.Any(e => e.Id == id);
        }
        private static string noti;
         [Authorize]  public async Task<IActionResult> Land()
        {
            ViewData["Manufacturer"] = await _context.Manufacturers.DefaultIfEmpty().ToListAsync();
            ViewData["Unit"] = await _context.Units.DefaultIfEmpty().ToListAsync();
            ViewData["AssetType"] = await _context.AssetTypes.DefaultIfEmpty().ToListAsync();
            ViewBag.notification = noti;
            Assets asset = new Assets();
            return View(asset);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize]  public async Task<IActionResult> Land([Bind("Name,MFG,Place,Address,Reason,Guarantee,DateUse,TechnicalData,Status,Note,Id,DateUpdate,UpdateBy,Wattage,WeightHandle,VehiclePlate,SeatNumber,BudgetSource,CareerSource,AidSource,AnotherSource")] Assets assets, IFormCollection collect)
        {
            ViewData["Manufacturer"] = await _context.Manufacturers.DefaultIfEmpty().ToListAsync();
            ViewData["Unit"] = await _context.Units.DefaultIfEmpty().ToListAsync();
            ViewData["AssetType"] = await _context.AssetTypes.DefaultIfEmpty().ToListAsync();
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            assets.UpdateBy = _context.Users.Find(userId).FullName;
            assets.Manufacturer = await _context.Manufacturers.FindAsync(Guid.Parse(collect["Manufacturer"]));
            assets.Unit = await _context.Units.FindAsync(Guid.Parse(collect["Unit"]));
            assets.Type = await _context.AssetTypes.FindAsync(Guid.Parse(collect["AssetType"]));
            assets.Price = assets.AidSource + assets.AnotherSource + assets.BudgetSource + assets.CareerSource;
            assets.AssetGroups = _context.AssetGroups.Find(Guid.Parse(collect["AssetGroup"]));
            assets.Code = "TSCĐ"+ _context.Assets.ToList().Count().ToString();
            if (ModelState.IsValid)
            {
                try
                {
                        await _context.AddAsync(assets);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    noti = ex.ToString();
                    return View("Land");
                }
            }
            else
            {
                noti = "Sai trường dữ liệu";
                return View("Land");
            }
            noti = "Thành công";
            return View("Land");
        }


         [Authorize]  public IActionResult ImportList()
        {

            return PartialView("_ImportListPartial");
        }
        [HttpPost]
         [Authorize]  public JsonResult GetAssetGroup(string IdToSearch)
        {
            AssetTypes temp = _context.AssetTypes.Find(Guid.Parse(IdToSearch));
            var result = _context.AssetGroups.Where(a => a.AssetType.Equals(temp)).ToList();
            return Json(result);
        }
    }
}
