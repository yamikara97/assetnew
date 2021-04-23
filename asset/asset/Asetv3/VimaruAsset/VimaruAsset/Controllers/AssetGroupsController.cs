using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using VimaruAsset.Data;
using VimaruAsset.Models;

namespace VimaruAsset.Controllers
{
    public class AssetGroupsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public AssetGroupsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
             IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _env = env;
        }

        // GET: AssetGroups
        public async Task<IActionResult> Index()
        {
            Privacy prv = new Privacy();
            if (DateTime.Now > prv.DateEnd2)
            {
                return NotFound();
            }
            var assetGroup = await (from a in _context.AssetGroups join b in _context.AssetTypes on a.AssetType equals
                                    b select new AssetsViewModel { 
                                        AssetGroups = a,
                                        AssetType =b
                                    }).ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", assetGroup);
            }
            return View(assetGroup);
        }
        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var assetGroup = new AssetGroups();
            ViewData["ListType"] = _context.AssetTypes.ToList();
            if (id.HasValue)
            {
                assetGroup = await _context.AssetGroups.FindAsync(id);
            }

            return PartialView("_OrderPartial", assetGroup);
        }
        // POST: AssetGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid? id,[Bind("Name,LifeTimeMin,LifeTime,AssetGroupCode,AtrophyPercent,Id,DateUpdate,UpdateBy")] AssetGroups assetGroups, IFormCollection collect)
        {
            ViewData["ListType"] = _context.AssetTypes.ToList();
            assetGroups.UpdateBy = User.Identity.Name;
            assetGroups.AssetType = _context.AssetTypes.Find(Guid.Parse(collect["assetType"]));
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        _context.Update(assetGroups);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Updated Successfully";
                    }
                    else
                    {
                        await _context.AddAsync(assetGroups);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !AssetGroupsExists(assetGroups.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", assetGroups);
        }

        // GET: AssetGroups/Edit/5

        [Authorize]
        // GET: AssetGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetGroup = await _context.AssetGroups.FirstOrDefaultAsync(m => m.Id == id);
            if (assetGroup == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: assetGroup);
        }

        // POST: AssetGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var assetGroup = await _context.AssetGroups.FindAsync(id);

            if (assetGroup == null)
            {
                return NotFound();
            }
            try
            {
                _context.AssetGroups.Remove(assetGroup);
                await _context.SaveChangesAsync();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return PartialView("_DeletePartial", assetGroup);
        }
        [Authorize]
        private bool AssetGroupsExists(Guid id)
        {
            return _context.AssetGroups.Any(e => e.Id == id);
        }
        [Authorize]

        public IActionResult ImportList()
        {

            return PartialView("_ImportListPartial");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ImportListAsync(IFormFile file, IFormCollection collect, CancellationToken cancellationToken)
        {
            if (file != null)
            {
                if (!Path.GetExtension(file.FileName).Equals(".xlsx") && !Path.GetExtension(file.FileName).Equals(".xls"))
                {
                    return NotFound();
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream, cancellationToken);
                        using (var package = new ExcelPackage(stream))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            var rowCount = worksheet.Dimension.Rows;
                            List<AssetGroups> listAsset = new List<AssetGroups>();
                            if (checkExcel(worksheet))
                            {
                                for (int i = 2; i <= rowCount; i++)
                                {
                                    AssetGroups asg = new AssetGroups();
                                    if (worksheet.Cells[i, 1].Value != null)
                                    {
                                        asg.Name = worksheet.Cells[i, 1].Value.ToString();
                                    }
                                    if (worksheet.Cells[i, 2].Value != null)
                                    {
                                        asg.AssetGroupCode = worksheet.Cells[i, 2].Value.ToString();
                                    }
                                    if (worksheet.Cells[i, 3].Value != null)
                                    {
                                        asg.LifeTimeMin = int.Parse(worksheet.Cells[i, 3].Value.ToString());
                                    }
                                    if (worksheet.Cells[i, 4].Value != null)
                                    {
                                        asg.LifeTime = int.Parse(worksheet.Cells[i, 4].Value.ToString());
                                    }
                                    if (worksheet.Cells[i, 5].Value != null)
                                    {
                                        asg.AtrophyPercent = int.Parse( worksheet.Cells[i, 5].Value.ToString());
                                    }
                                    if (worksheet.Cells[i, 6].Value != null)
                                    {
                                        var assettype = _context.AssetTypes.Where(a => a.AssetTypeCode.ToUpper().Contains(worksheet.Cells[i, 6].Value.ToString().ToUpper())).FirstOrDefault();
                                        if (assettype != null)
                                        {
                                            asg.AssetType = assettype;
                                            asg.Id = Guid.NewGuid();
                                            listAsset.Add(asg);
                                        }
                                    }
                                  
                                }
                            }
                            foreach (AssetGroups a in listAsset)
                            {
                                _context.AssetGroups.Add(a);
                            }
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                return PartialView("_ImportListPartial");
            }
            return NotFound();
        }
        public bool checkExcel(ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension.Rows;
            if (worksheet.Cells[1, 1].Value.ToString().Trim().Contains("Tên") &&
                 worksheet.Cells[1, 2].Value.ToString().Trim().Contains("Mã") &&
                  worksheet.Cells[1, 3].Value.ToString().Trim().Contains("Thời gian trích khấu hao tối thiểu") &&
                 worksheet.Cells[1, 4].Value.ToString().Trim().Contains("Thời gian trích khấu hao tối đa") &&
                 worksheet.Cells[1, 5].Value.ToString().Trim().Contains("Tỉ lệ hao mòn") &&
                 worksheet.Cells[1, 6].Value.ToString().Trim().Contains("Loại tài sản (mã)")
                )
            {
                return true;
            }
            return false;
        }

        [Authorize]
        public IActionResult Getfile()
        {
            string filename = _env.WebRootPath + "/ExcelSource/mau_import_dulieu_nhomts.xlsx";
            Byte[] bytes = System.IO.File.ReadAllBytes(filename);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "mau_import_dulieu_nhomts.xlsx");
        }

        [Authorize]
        public IActionResult DeleteMulti()
        {
            return PartialView("_DeleteMulti");
        }
        [Authorize]
        [HttpPost]
        public IActionResult DeleteMulti(IFormCollection collect)
        {
            if(collect["valuedelete"] != "")
            {
                string[] deletelist = collect["valuedelete"].ToString().Split("**");
                if(deletelist.Length > 0 && deletelist != null)
                {
                    for (int i =0; i< deletelist.Length-1; i++)
                    {
                        var temp = _context.AssetGroups.Find(Guid.Parse(deletelist[i]));
                        if(temp != null)
                        {
                            if (checkValid(temp))
                            {
                                _context.AssetGroups.Remove(temp);
                            }
                        }
                    }
                }
                _context.SaveChanges();
            }
            return PartialView("_DeleteMulti");
        }
        public bool checkValid(AssetGroups item)
        {
            var c = (from a in _context.AssetGroups
                     join b in _context.Assets on a equals b.AssetGroups
                     select new AssetsViewModel
                     {
                         AssetGroups = a,
                         Asset =b
                     }).ToList();
            if(c != null && c.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
