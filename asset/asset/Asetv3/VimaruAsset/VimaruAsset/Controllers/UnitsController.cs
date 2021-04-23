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
    public class UnitsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public UnitsController(
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

        // GET: Units
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var unit = await _context.Units.ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", unit);
            }
            return View(unit);
        }

        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {

            var unit = new Unit();

            if (id.HasValue)
            {
                unit = await _context.Units.FindAsync(id);

            }

            return PartialView("_OrderPartial", unit);
        }

        // POST: Units/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid? id, [Bind("UnitName,Note,Id,DateUpdate")] Unit unit)
        {
            unit.UpdateBy = User.Identity.Name;
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        _context.Update(unit);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Updated Successfully";
                    }
                    else
                    {
                        await _context.AddAsync(unit);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !UnitExists(unit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", unit);
        }
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units.FirstOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: unit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
            {
                return NotFound();
            }

            try
            {
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return PartialView("_DeletePartial", unit);
        }
        private bool UnitExists(Guid id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
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
                            List<Unit> listAsset = new List<Unit>();
                            if (checkExcel(worksheet))
                            {
                                for (int i = 2; i <= rowCount; i++)
                                {
                                    Unit asg = new Unit();
                                    if (worksheet.Cells[i, 1].Value != null)
                                    {
                                        asg.UnitName = worksheet.Cells[i, 1].Value.ToString();
                                    }
                                    if (worksheet.Cells[i, 2].Value != null)
                                    {
                                        asg.Note = worksheet.Cells[i, 2].Value.ToString();
                                    }
                                    listAsset.Add(asg);
                                }
                            }
                            foreach (Unit a in listAsset)
                            {
                                _context.Units.Add(a);
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
                 worksheet.Cells[1, 2].Value.ToString().Trim().Contains("Ghi chú")
                )
            {
                return true;
            }
            return false;
        }

        [Authorize]
        public IActionResult Getfile()
        {
            string filename = _env.WebRootPath + "/ExcelSource/mau_import_dulieu_dvt.xlsx";
            Byte[] bytes = System.IO.File.ReadAllBytes(filename);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "mau_import_dulieu_dvt.xlsx");
        }
    }
}
