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
    public class DepartmentsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public DepartmentsController(
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
        [Authorize]
        public async Task<IActionResult> Index()
        {

            var department = await _context.Department.ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", department);
            }
            return View(department);
        }

        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var i = Request.Query["Code"];
            ViewBag.Father = "";
            if (i != "")
            {
                ViewBag.Father = i;
            }
            var department = new Department();

            if (id.HasValue)
            {

                department = await _context.Department.FindAsync(id);
                ViewBag.Father = department.FatherID;
            }

            return PartialView("_OrderPartial", department);
        }

        public string getCode(string father, string name)
        {
            string[] namearray = name.Trim().Split(" ");
            string valref = father == null ? "" : (father + "_");
            for(int i =0; i< namearray.Count() ;i ++)
            {
                if(namearray[i] != null && namearray[i] != "")
                {
                    if(i == namearray.Count() - 1)
                    {
                        if (long.TryParse(namearray[i],out long ret))
                        {
                            valref += namearray[i];
                        }
                        else
                        {
                            valref += namearray[i].ToString().ToUpper();
                         
                        }
                    }
                    else
                    {
                        valref += namearray[i][0].ToString().ToUpper();
                    }
                    
                }
            }
            return valref;
        }

        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid? id,[Bind("Name,Code,Note,ManagerName,Address,Id,DateUpdate,FatherID,UpdateBy")] Department department, IFormCollection collect)
        {
            department.UpdateBy = User.Identity.Name;
          
            department.Code = getCode(department.FatherID, department.Name);
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        if (collect["oldCode"] != "")
                        {
                            var listdep = _context.Department.Where(a => a.Id != department.Id).ToList();
                            foreach (var item in listdep)
                            {
                                if (item.Code != "" && item.Code != null)
                                {
                                    if (item.FatherID != null && item.FatherID.Contains(collect["oldCode"]))
                                    {
                                        item.FatherID = item.FatherID.Replace(collect["oldCode"], department.Code);
                                        _context.Department.Update(item);
                                    }
                                }
                            }
                        }
                        _context.Department.Update(department);
                        _context.SaveChanges();
                        TempData["Notifications"] = "Sửa thành công";
                    }
                    else
                    {
                        var test = _context.Department.Where(a => a.Name == department.Name || a.Code == department.Code).FirstOrDefault();
                        if (test == null)
                        {

                            _context.Department.Add(department);
                        }

                        var wh = new WareHouse();
                        wh.Name = "Sổ " + department.FatherID + "-" + department.Name;
                        wh.Id = Guid.NewGuid();
                        wh.department = department;
                        _context.WareHouse.Add(wh);
                         _context.SaveChanges();
                        TempData["Notifications"] = " Thêm thành công";

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !DepartmentExists(department.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Index","Departments");
        }
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: department);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var department = await _context.Department.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            try
            {
                foreach (var item in _context.Department)
                {
                    if (item.FatherID == department.Code)
                    {
                        item.FatherID = "";
                        _context.Department.Update(item);
                    }
                }
                foreach(var item in _context.WareHouse)
                {
                    if(item.department == department)
                    {
                        item.department = null;
                        _context.WareHouse.Update(item);
                    }
                }
                _context.Department.Remove(department);
               
                 _context.SaveChanges();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", department);
        }
        [Authorize]
        private bool DepartmentExists(Guid id)
        {
            return _context.Department.Any(e => e.Id == id);
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
                            List<Department> listAsset = new List<Department>();
                            if (checkExcel(worksheet))
                            {
                                for (int i = 2; i <= rowCount; i++)
                                {
                                    Department asg = new Department();
                                    if (worksheet.Cells[i, 1].Value != null)
                                    {
                                        asg.Name = worksheet.Cells[i, 1].Value.ToString();
                                    }
                               
                                    if (worksheet.Cells[i, 3].Value != null)
                                    {
                                        asg.Note = worksheet.Cells[i, 3].Value.ToString();
                                    }
                                    if (worksheet.Cells[i, 4].Value != null)
                                    {
                                        asg.ManagerName = worksheet.Cells[i, 4].Value.ToString();
                                    }
                                    if (worksheet.Cells[i, 5].Value != null)
                                    {
                                        asg.FatherID = worksheet.Cells[i, 5].Value.ToString();
                                    }
                                    else
                                    {
                                        asg.FatherID = "";
                                    }
                                    if (worksheet.Cells[i, 2].Value != null)
                                    {
                                        asg.Code = worksheet.Cells[i, 2].Value.ToString();
                                    }
                                    else
                                    {
                                        asg.Code = getCode(asg.Code,asg.Name);
                                    }
                                    listAsset.Add(asg);
                                }
                            }
                            Console.Write(listAsset.Count());
                            foreach (Department aa in listAsset)
                            {
                                var test = _context.Department.Where(a => a.Name == aa.Name && a.Code == aa.Code).FirstOrDefault();
                                if (test == null)
                                {
                                    _context.Department.Add(aa);
                                    var wh = new WareHouse();
                                    wh.Id = Guid.NewGuid();
                                    wh.Name = "Sổ " + aa.Name;
                                    wh.department = aa;
                                    _context.WareHouse.Add(wh);
                                }

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
                 worksheet.Cells[1, 3].Value.ToString().Trim().Contains("Địa điểm") &&
                 worksheet.Cells[1, 4].Value.ToString().Trim().Contains("Trưởng bộ phận") &&
                  worksheet.Cells[1, 5].Value.ToString().Trim().Contains("Mã bộ phận cha")
                )
            {
                return true;
            }
            return false;
        }

        [Authorize]
        public IActionResult Getfile()
        {
            string filename = _env.WebRootPath + "/ExcelSource/mau_import_dulieu_phongban.xlsx";
            Byte[] bytes = System.IO.File.ReadAllBytes(filename);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "mau_import_dulieu_phongban.xlsx");
        }
    }
}
