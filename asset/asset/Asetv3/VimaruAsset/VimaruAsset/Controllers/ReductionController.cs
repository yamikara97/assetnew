using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using QRCoder;
using VimaruAsset.Data;
using VimaruAsset.Models;

namespace VimaruAsset.Controllers
{
    public class ReductionController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        public ReductionController(
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

        // GET: Assets
        private static Guid CurrentSelected;

        // GET: MyWareHouse
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            Guid idToFind = _context.UserRoles.Where(a => a.UserId.Equals(Guid.Parse(userId))).FirstOrDefault().RoleId;
            var role = _context.Roles.Find(idToFind);
            var departments = _context.Department.Where(a => a == user.Department).FirstOrDefault();
            List<WareHouse> WareHouse = await _context.WareHouse.ToListAsync();
            if (role.Name != "Admin")
            {
                WareHouse = await _context.WareHouse.Where(a => a.department == departments).ToListAsync();
            }
            ViewData["ListType"] = await _context.AssetTypes.ToListAsync();
            ViewData["ListGroup"] = await _context.AssetGroups.ToListAsync();
            ViewData["MyWareHouses"] = WareHouse;
            Guid selectID = WareHouse.First().Id;
            if (CurrentSelected != null && CurrentSelected != Guid.Empty)
            {
                selectID = CurrentSelected;
            }
            else
            {
                CurrentSelected = selectID;
            }
            ViewBag.SelectID = selectID;
            ViewBag.searchQR = selectID;
            var assetList = await (from asset in _context.Assets
                                   join assettype in _context.AssetTypes on asset.Type equals assettype into join1

                                   from j1 in join1.DefaultIfEmpty()
                                   join unit in _context.Units on asset.Unit equals unit into join2

                                   from j2 in join2.DefaultIfEmpty()
                                   join warehouse in _context.WareHouse on asset.WareHouse equals warehouse into join3

                                   from j3 in join3.DefaultIfEmpty()
                                   join manufact in _context.Manufacturers on asset.Manufacturer equals manufact into join4
                                   from j4 in join4.DefaultIfEmpty()


                                   join department in _context.Department on j3.department equals department into join5
                                   from j5 in join5.DefaultIfEmpty()

                                   where j3.Id.Equals(selectID)


                                   select new AssetsViewModel()
                                   {
                                       Asset = asset,
                                       AssetType = j1,
                                       Unit = j2,
                                       Warehouse = j3,
                                       Manufacturer = j4,
                                       Department = j5
                                   }
                              ).ToListAsync();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", assetList);
            }
            return View(assetList);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(IFormCollection collect)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            Guid idToFind = _context.UserRoles.Where(a => a.UserId.Equals(Guid.Parse(userId))).FirstOrDefault().RoleId;
            var role = _context.Roles.Find(idToFind);
            List<WareHouse> WareHouse = await _context.WareHouse.ToListAsync();
            ViewData["ListType"] = await _context.AssetTypes.ToListAsync();
            ViewData["ListGroup"] = await _context.AssetGroups.ToListAsync();
            var departments = _context.Department.Where(a => a == user.Department).FirstOrDefault();
            if (role.Name != "Admin")
            {
                WareHouse = await _context.WareHouse.Where(a => a.department == departments).ToListAsync();
            }
            ViewData["MyWareHouses"] = WareHouse;
            Guid selectID = new Guid();
            if (collect != null && collect["warehouse"] != "")
            {
                string id = collect["warehouse"];
                selectID = Guid.Parse(id);
            }
            ViewBag.searchQR = selectID;
            var assetList = await (from asset in _context.Assets
                                   join assettype in _context.AssetTypes on asset.Type equals assettype into join1

                                   from j1 in join1.DefaultIfEmpty()
                                   join unit in _context.Units on asset.Unit equals unit into join2

                                   from j2 in join2.DefaultIfEmpty()
                                   join warehouse in _context.WareHouse on asset.WareHouse equals warehouse into join3

                                   from j3 in join3.DefaultIfEmpty()
                                   join manufact in _context.Manufacturers on asset.Manufacturer equals manufact into join4

                                   from j4 in join4.DefaultIfEmpty()


                                   join department in _context.Department on j3.department equals department into join5
                                   from j5 in join5.DefaultIfEmpty()

                                   where j3.Id.Equals(selectID)


                                   select new AssetsViewModel()
                                   {
                                       Asset = asset,
                                       AssetType = j1,
                                       Unit = j2,
                                       Warehouse = j3,
                                       Manufacturer = j4,
                                       Department = j5
                                   }
                              ).ToListAsync();
            if(assetList != null)
            {
                if (collect["AssetGroupS"] != "")
                {
                    assetList = assetList.Where(a => a.AssetGroups != null && a.AssetGroups.Id == Guid.Parse(collect["AssetGroupS"])).ToList();
                }
                if (collect["AssetTypeS"] != "")
                {
                    assetList = assetList.Where(a => a.AssetType != null && a.AssetType.Id == Guid.Parse(collect["AssetTypeS"])).ToList();
                }
                if (collect["Fromdate"] != "")
                {
                    var t1 = DateTime.Parse(collect["Fromdate"]);
                    if (t1 != DateTime.MinValue)
                    {
                        assetList = assetList.Where(a => a.Asset.DateUse > t1).ToList();
                    }
                }
                if (collect["Todate"] != "")
                {
                    var t2 = DateTime.Parse(collect["Todate"]);

                    if (t2 != DateTime.MinValue)
                    {
                        assetList = assetList.Where(a => a.Asset.DateUse < t2).ToList();
                    }
                }
            }
            



            return View(assetList);
        }
        [Authorize]
        public async Task<IActionResult> ChangeWarehouse(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            ViewData["listWareHouse"] = await _context.WareHouse.ToListAsync();
            return PartialView("_ChangeWareHousePartial", asset);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangeWarehouse(Guid? id, IFormCollection collect)
        {
            Assets asset = new Assets();
            asset = await _context.Assets.FindAsync(Guid.Parse(collect["AssetId"]));
            asset.WareHouse = await _context.WareHouse.FindAsync(Guid.Parse(collect["WareHouse"]));
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
            return PartialView("_ChangeWareHousePartial", asset);
        }
        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            ViewData["ListDepartment"] = await _context.Department.ToListAsync();
            return PartialView("_OrderPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(IFormCollection collect)
        {
            int count = 0;
           if(collect["AssetBook"] != "")
            {
                if(collect["__RequestVerificationToken"] != "")
                {
                    string[] str = collect["valueReturn"].ToString().Split("**");
                    for(int i =0; i< str.Length-1; i++)
                    {
                        count++;
                            var asset = _context.Assets.Find(Guid.Parse(str[i]));
                            asset.WareHouse = _context.WareHouse.Find(Guid.Parse(collect["AssetBook"]));
                           _context.Assets.Update(asset);
             
                    }
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var user = await _userManager.FindByIdAsync(userId);
                    ReductionHistory his = new ReductionHistory();
                    his.Reason = collect["Reason"];
                    var department = (from a in _context.Users join b in _context.Department on a.Department equals b
                                      select new AssetsViewModel
                                      {
                                          User = a,
                                          Department = b
                                      }).FirstOrDefault();
                    his.DayMove = DateTime.Now;
                    his.Frombook = _context.WareHouse.Find(Guid.Parse(collect["wareHouseID"])).Name;   
                    his.ToDepartment = _context.Department.Find(Guid.Parse(collect["Department"])).Name;
                    his.ToBook = _context.WareHouse.Find(Guid.Parse(collect["AssetBook"])).Name;
                    his.NumberofAsset = count   ;
                    _context.ReductionHistories.Add(his);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            return PartialView("_OrderPartial");
        }

        
       
        [HttpPost]
        [Authorize]
        public JsonResult GetUser(string IdToSearch)
        {
            Department temp = _context.Department.Find(Guid.Parse(IdToSearch));
            var result = _context.Users.Where(a => a.Department.Equals(temp)).ToList();
            return Json(result);
        }

        [HttpPost]
        [Authorize]
        public JsonResult GetBook(string IdToSearch)
        {
            Department temp = _context.Department.Find(Guid.Parse(IdToSearch));
            var result = _context.WareHouse.Where(a => a.department.Equals(temp)).ToList();
            return Json(result);
        }
    }
}
