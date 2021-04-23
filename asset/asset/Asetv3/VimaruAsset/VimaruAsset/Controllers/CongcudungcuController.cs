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
    public class CongcudungcuController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public CongcudungcuController(
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


        // GET: Assets
        private static Guid CurrentSelected;

        [Authorize]
        // GET: MyWareHouse
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            Guid idToFind = _context.UserRoles.Where(a => a.UserId.Equals(Guid.Parse(userId))).FirstOrDefault().RoleId;
            var role = _context.Roles.Find(idToFind);
            List<WareHouse> WareHouse = await _context.WareHouse.ToListAsync();
            ViewData["MyWareHouse"] = WareHouse;
            Guid selectID = WareHouse.First().Id;
            if (CurrentSelected != null && CurrentSelected != Guid.Empty)
            {
                selectID = CurrentSelected;
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

                                   where j3.Id.Equals(selectID) && j1.AssetTypeCode == "LTS-K"


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
            if (role.Name != "Admin" && !role.Name.Contains("Quản trị"))
            {
                assetList = assetList.Where(a => a.User.Id == Guid.Parse(userId)).ToList();
            }
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

            ViewData["MyWareHouse"] = WareHouse;
            Guid selectID = new Guid();
            if (collect != null && collect["warehouse"] != "")
            {
                string id = collect["warehouse"];
                selectID = Guid.Parse(id);
            }
            CurrentSelected = selectID;
            ViewBag.SelectID = CurrentSelected;
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

                                   where j3.Id.Equals(selectID) && j1.AssetTypeCode == "LTS-K"


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
            if (role.Name != "Admin" && !role.Name.Contains("Quản trị"))
            {
                assetList = assetList.Where(a => a.User.Id == Guid.Parse(userId)).ToList();
            }
            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    return PartialView("_DataTablePartial", assetList);
            //}
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
            var asset = new Assets();



            if (id.HasValue)
            {
                asset = await _context.Assets.FindAsync(id);
            }


            ViewData["Manufacturer"] = await _context.Manufacturers.DefaultIfEmpty().ToListAsync();
            ViewData["Unit"] = await _context.Units.DefaultIfEmpty().ToListAsync();
            var type = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-K").FirstOrDefault();
            ViewData["AssetGroup"] = await _context.AssetGroups.Where(a => a.AssetType == type).ToListAsync();
            return PartialView("_OrderPartial", asset);
        }

        // POST: MyWareHouse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid? id, [Bind("Name,Amount,MFG,Place,Address,Reason,Guarantee,DateUse,TechnicalData,Status,Note,Id,DateUpdate,UpdateBy,Wattage,WeightHandle,VehiclePlate,SeatNumber,BudgetSource,CareerSource,AidSource,AnotherSource")] Assets assets, IFormCollection collect)
        {
            ViewData["Manufacturer"] = await _context.Manufacturers.DefaultIfEmpty().ToListAsync();
            ViewData["Unit"] = await _context.Units.DefaultIfEmpty().ToListAsync();
            ViewData["AssetType"] = await _context.AssetTypes.DefaultIfEmpty().ToListAsync();
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            assets.UpdateBy = _context.Users.Find(userId).FullName;
            assets.Manufacturer = await _context.Manufacturers.FindAsync(Guid.Parse(collect["Manufacturer"]));
            assets.Unit = await _context.Units.FindAsync(Guid.Parse(collect["Unit"]));
            assets.Type = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-K").FirstOrDefault();
            assets.WareHouse = await _context.WareHouse.FindAsync(Guid.Parse(collect["wareHouseID"]));
            assets.Price = assets.AidSource + assets.AnotherSource + assets.BudgetSource + assets.CareerSource;
            assets.AssetGroups = _context.AssetGroups.Find(Guid.Parse(collect["AssetGroup"]));
            var count = _context.Assets.Count();
            assets.Code = "TSCD" + count.ToString(); 
            Guid identify = Guid.NewGuid();
            assets.identify = identify;
            CurrentSelected = Guid.Parse(collect["wareHouseID"]);
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        _context.Update(assets);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Updated Successfully";
                    }
                    else
                    {
                        if (assets.Amount > 1)
                        {
                            int tcount = assets.Amount;
                            for (int i = 0; i < tcount; i++)
                            {
                                var ase = new Assets();
                                ase = assets;
                                ase.Id = Guid.NewGuid();
                                ase.Amount = 1;
                                var count2 = _context.Assets.Count();
                                ase.Code = "TSCD" + count2.ToString();
                                ase.identify = identify;
                                _context.Assets.Add(ase);
                                _context.SaveChanges();
                            }
                        }
                        else
                        {
                            await _context.AddAsync(assets);
                        }
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !AssetsExists(assets.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", assets);
        }
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Assets.FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: asset);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id, IFormCollection collect)
        {
            var asset = await _context.Assets.FindAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            try
            {
                CurrentSelected = Guid.Parse(collect["wareHouseID2"]);
                _context.Assets.Remove(asset);
                await _context.SaveChangesAsync();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return PartialView("_DeletePartial", asset);
        }
        private bool UnitExists(Guid id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
        private bool AssetsExists(Guid id)
        {
            return _context.Assets.Any(e => e.Id == id);
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
                        Guid userId = Guid.Parse(_userManager.GetUserId(User));
                        WareHouse warehouse = await _context.WareHouse.FindAsync(Guid.Parse(collect["wareHouseId"]));
                        using (var package = new ExcelPackage(stream))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            var rowCount = worksheet.Dimension.Rows;
                            List<Assets> listAsset = new List<Assets>();
                            if (checkExcel(worksheet))
                            {
                                for (int i = 2; i <= rowCount; i++)
                                {
                                    Assets asset = new Assets();
                                    asset.Code = "TSCD" + _context.Assets.Count();
                                    asset.Type = _context.AssetTypes.Where(a => a.AssetTypeName.Contains("Đất")).FirstOrDefault();
                                    asset.Name = worksheet.Cells[i, 1].Value.ToString();
                                    if (worksheet.Cells[i, 2].Value != null)
                                    {
                                        DateTime d1;
                                        if (DateTime.TryParse(worksheet.Cells[i, 2].Value.ToString(), out d1))
                                        {
                                            asset.MFG = d1;
                                        }
                                    }
                                    if (worksheet.Cells[i, 3].Value != null)
                                    {
                                        DateTime d2;
                                        if (DateTime.TryParse(worksheet.Cells[i, 3].Value.ToString(), out d2))
                                        {
                                            asset.Guarantee = d2;
                                        }
                                    }
                                    if (worksheet.Cells[i, 4].Value != null)
                                    {
                                        Manufacturer manufacturer = _context.Manufacturers.Where(a => a.Name.ToLower().CompareTo(worksheet.Cells[i, 4].Value.ToString().Trim().ToLower()) == 0).DefaultIfEmpty().First();
                                        if (manufacturer != null)
                                        {
                                            asset.Manufacturer = manufacturer;
                                        }
                                        else if (worksheet.Cells[i, 4].Value.ToString() != "")
                                        {
                                            Manufacturer man = new Manufacturer();
                                            man.Id = Guid.NewGuid();
                                            man.Name = worksheet.Cells[i, 4].Value.ToString();
                                            _context.Manufacturers.Add(man);
                                            await _context.SaveChangesAsync();
                                            asset.Manufacturer = man;
                                        }
                                    }
                                    if (worksheet.Cells[i, 5].Value != null)
                                    {
                                        AssetGroups groups = _context.AssetGroups.Where(a => a.Name.ToLower().CompareTo(worksheet.Cells[i, 5].Value.ToString().Trim().ToLower()) == 0).DefaultIfEmpty().First();
                                        if (groups != null)
                                        {
                                            asset.AssetGroups = groups;
                                        }
                                        else
                                        {
                                            groups = _context.AssetGroups.Where(a => a.AssetGroupCode.ToLower().CompareTo(worksheet.Cells[i, 5].Value.ToString().Trim().ToLower()) == 0).DefaultIfEmpty().First();
                                        }
                                    }
                                    if (worksheet.Cells[i, 6].Value != null)
                                    {
                                        Unit unit = _context.Units.Where(a => a.UnitName.ToLower().CompareTo(worksheet.Cells[i, 6].Value.ToString().Trim().ToLower()) == 0).DefaultIfEmpty().First();
                                        if (unit != null)
                                        {
                                            asset.Unit = unit;
                                        }
                                        else if (worksheet.Cells[i, 6].Value.ToString() != "")
                                        {
                                            Unit un = new Unit();
                                            un.Id = Guid.NewGuid();
                                            un.UnitName = worksheet.Cells[i, 6].Value.ToString();
                                            _context.Units.Add(un);
                                            await _context.SaveChangesAsync();
                                            asset.Unit = un;
                                        }
                                    }
                                    if (worksheet.Cells[i, 7].Value != null)
                                    {
                                        asset.TechnicalData = worksheet.Cells[i, 7].Value.ToString();
                                    }
                                    if (worksheet.Cells[i, 8].Value != null)
                                    {
                                        double db;
                                        if (double.TryParse(worksheet.Cells[i, 8].Value.ToString(), out db))
                                        {
                                            asset.Price = db;
                                        }

                                    }
                                    if (worksheet.Cells[i, 9].Value != null)
                                    {
                                        if ("Hỏng".ToLower().CompareTo(worksheet.Cells[i, 9].Value.ToString().Trim()) == 0)
                                        {
                                            asset.Status = Assets.Statuses.GOOD;
                                        }
                                        else if ("Bảo trì".ToLower().CompareTo(worksheet.Cells[i, 9].Value.ToString().Trim()) == 0)
                                        {
                                            asset.Status = Assets.Statuses.MAINTENANCE;
                                        }
                                        else
                                        {
                                            asset.Status = Assets.Statuses.GOOD;
                                        }
                                    }
                                    if (worksheet.Cells[i, 10].Value != null)
                                    {
                                        asset.Note = worksheet.Cells[i, 10].Value.ToString();
                                    }
                                    if (worksheet.Cells[i, 11].Value != null)
                                    {
                                        asset.Address = worksheet.Cells[i, 11].Value.ToString();
                                    }
                                    if (worksheet.Cells[i, 12].Value != null)
                                    {
                                        DateTime d1;
                                        if (DateTime.TryParse(worksheet.Cells[i, 12].Value.ToString(), out d1))
                                        {
                                            asset.DateUse = d1;
                                        }
                                    }
                                    if (worksheet.Cells[i, 13].Value != null)
                                    {
                                        asset.Amount = int.Parse(worksheet.Cells[i, 13].Value.ToString());
                                    }
                                    if (worksheet.Cells[i, 14].Value != null)
                                    {
                                        asset.Reason = worksheet.Cells[i, 14].Value.ToString();
                                    }
                                    asset.Id = Guid.NewGuid();
                                    asset.DateUpdate = DateTime.Now;
                                    asset.UpdateBy = _context.Users.Find(userId).FullName;
                                    asset.WareHouse = warehouse;
                                    listAsset.Add(asset);
                                }
                            }
                            foreach (Assets a in listAsset)
                            {
                                _context.Assets.Add(a);
                            }
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                CurrentSelected = Guid.Parse(collect["wareHouseId"]);
                return PartialView("_ImportListPartial");
            }
            return NotFound();
        }
        public bool checkExcel(ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension.Rows;
            if (worksheet.Cells[1, 1].Value.ToString().Trim().Contains("Tên") &&
                 worksheet.Cells[1, 2].Value.ToString().Trim().Contains("Ngày sản xuất") &&
                 worksheet.Cells[1, 3].Value.ToString().Trim().Contains("Hạn bảo hành") &&
                 worksheet.Cells[1, 4].Value.ToString().Trim().Contains("Tên nhà sản xuất") &&
                 worksheet.Cells[1, 5].Value.ToString().Trim().Contains("Nhóm tài sản (hoặc mã)") &&
                 worksheet.Cells[1, 6].Value.ToString().Trim().Contains("Đơn vị tính") &&
                 worksheet.Cells[1, 7].Value.ToString().Trim().Contains("Số liệu kỹ thuật") &&
                 worksheet.Cells[1, 8].Value.ToString().Trim().Contains("Tổng nguyên giá") &&
                 worksheet.Cells[1, 9].Value.ToString().Trim().Contains("Tình trạng") &&
                 worksheet.Cells[1, 10].Value.ToString().Trim().Contains("Ghi chú") &&
                 worksheet.Cells[1, 11].Value.ToString().Trim().Contains("Đặt tại") &&
                 worksheet.Cells[1, 12].Value.ToString().Trim().Contains("Ngày đưa vào sử dụng") &&
                 worksheet.Cells[1, 13].Value.ToString().Trim().Contains("Số lượng") &&
                 worksheet.Cells[1, 14].Value.ToString().Trim().Contains("Lý do tăng")
                )
            {
                return true;
            }
            return false;
        }

        [Authorize]
        public IActionResult Getfile()
        {
            string filename = _env.WebRootPath + "/ExcelSource/mau_import_dulieu.xlsx";
            Byte[] bytes = System.IO.File.ReadAllBytes(filename);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "mau_import_dulieu.xlsx");
        }
        [HttpPost]
        public JsonResult GetAssetGroup(string IdToSearch)
        {
            AssetTypes temp = _context.AssetTypes.Find(Guid.Parse(IdToSearch));
            var result = _context.AssetGroups.Where(a => a.AssetType.Equals(temp)).ToList();
            return Json(result);
        }
    }
}
