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

namespace Vimaru.Asset.Controllers
{
    public class AssetsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        public AssetsController(
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
            Privacy prv = new Privacy();
            if (DateTime.Now > prv.DateEnd2)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
        
           
            Guid idToFind = _context.UserRoles.Where(a => a.UserId.Equals(Guid.Parse(userId))).FirstOrDefault().RoleId;
            var role = _context.Roles.Find(idToFind);
            var x = (from a in _context.Users
                     join b in _context.Department on a.Department equals b
                     where a.Id == Guid.Parse(userId)
                     select new AssetsViewModel
                     {
                         User = a,
                         Department = b
                     }
                    ).FirstOrDefault();

            List<WareHouse> WareHouse = await _context.WareHouse.ToListAsync();
            if (role.Name != "Admin" && role.Name != "Manager" && role.Name != "ManagerApprove")
            {
                
                var departments = _context.Department.Where(a => a == x.Department).FirstOrDefault();
                WareHouse = await _context.WareHouse.Where(a => a.department == departments).ToListAsync();
                List<Department> d = _context.Department.Where(a => a.FatherID == departments.Code).ToList();
                foreach(var item in d)
                {
                    var listW = _context.WareHouse.Where(a => a.department == item).ToList();
                    foreach(var i in listW)
                    {
                        WareHouse.Add(i);
                    }
                }
            }
            ViewData["ListType"] = await _context.AssetTypes.ToListAsync();
            ViewData["ListGroup"] = await _context.AssetGroups.ToListAsync();
            ViewData["MyWareHouses"] = WareHouse;
            var warehtemp = WareHouse.FirstOrDefault();
            if(warehtemp != null)
            {
                Guid selectID = WareHouse.FirstOrDefault().Id;
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
                if (role.Name != "Admin" && role.Name != "Manager" && role.Name != "ManagerApprove")
                {
                    assetList = assetList.Where(a => a.Department.Code == x.Department.Code || a.Department.FatherID == x.Department.Code).ToList();
                }

                ViewData["listAssetOwned"] = assetList;



                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_DataTablePartial", assetList);
                }
                return View(assetList);
            }
            else
            {
                Guid selectID = Guid.Empty;
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
                if (role.Name != "Admin" && role.Name != "Manager" && role.Name != "ManagerApprove")
                {
                    assetList = assetList.Where(a => a.Department.Code == x.Department.Code || a.Department.FatherID == x.Department.Code).ToList();
                }

                ViewData["listAssetOwned"] = assetList;



                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_DataTablePartial", assetList);
                }
                return View(assetList);
            }
        }

        public bool checkedexist(List<AssetsViewModel> assets, AssetsViewModel asset)
        {
            foreach (var item in assets)
            {
                if (item.Asset.Id == asset.Asset.Id && item.Asset != null)
                {
                    return true;
                }
            }
            return false;
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
            var x = (from a in _context.Users
                     join b in _context.Department on a.Department equals b
                     where a.Id == Guid.Parse(userId)
                     select new AssetsViewModel
                     {
                         User = a,
                         Department = b
                     }
                 ).FirstOrDefault();
            if (role.Name != "Admin" && role.Name != "Manager" && role.Name != "ManagerApprove")
            {
             
                var departments = _context.Department.Where(a => a == x.Department).FirstOrDefault();
                WareHouse = await _context.WareHouse.Where(a => a.department == departments).ToListAsync();
                List<Department> d = _context.Department.Where(a => a.FatherID == departments.Code).ToList();
                foreach (var item in d)
                {
                    var listW = _context.WareHouse.Where(a => a.department == item).ToList();
                    foreach (var i in listW)
                    {
                        WareHouse.Add(i);
                    }
                }
            }
            ViewData["MyWareHouses"] = WareHouse;
            Guid selectID = new Guid();
            selectID = Guid.Empty;
            if (collect != null && collect["warehouse"] != "")
            {
                if (collect["warehouse"] != "All")
                {
                    string id = collect["warehouse"];
                    selectID = Guid.Parse(id);
                }
              
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

                                   join groups in _context.AssetGroups on asset.AssetGroups equals groups into join6
                                   from j6 in join6.DefaultIfEmpty()

                                 

                                   select new AssetsViewModel()
                                   {
                                       Asset = asset,
                                       AssetType = j1,
                                       Unit = j2,
                                       Warehouse = j3,
                                       Manufacturer = j4,
                                       Department = j5,
                                       AssetGroups = j6
                                   }
                              ).ToListAsync();

            if (role.Name != "Admin" && role.Name != "Manager" && role.Name != "ManagerApprove")
            {
                assetList = assetList.Where(a => a.Department.Code == x.Department.Code || a.Department.FatherID == x.Department.Code).ToList();
            }

            var newassset = new List<AssetsViewModel>();

            ViewData["listAssetOwned"] = assetList;

            if (collect["warehouse"] != "All")
            {
                if (selectID != Guid.Empty)
                {
                    if (assetList != null)
                    {
                        var temp = (from wh in _context.WareHouse
                                    join deb in _context.Department on wh.department equals deb into join1
                                    from j1 in join1.DefaultIfEmpty()
                                    where wh.Id == selectID
                                    select new AssetsViewModel
                                    {
                                        Warehouse = wh,
                                        Department = j1
                                    }
                  ).FirstOrDefault();
                        if (temp != null)
                        {

                            if(temp.Department == null)
                            {
                                return NotFound();
                            }
                            newassset = assetList.Where(a => a.Department.Code == temp.Department.Code || (a.Department.FatherID != null && a.Department.FatherID.Contains(temp.Department.Code))).ToList();
                        }
                        else
                        {
                            newassset = assetList.Where(a => a.Warehouse.Id == selectID).ToList();

                        }
                    }
      
                }
            }
            else
            {
                newassset = assetList;
            }

            if (collect["AssetTypeS"] != "________")
            {
                if (newassset != null)
                {
                    newassset = newassset.Where(a => a.AssetType != null && a.AssetType.Id == Guid.Parse(collect["AssetTypeS"])).DefaultIfEmpty().ToList();
                }

            }

            if (collect["AssetGroupS"] != "________")
            {
                if (newassset != null)
                {
                    newassset = newassset.Where(a => a.AssetGroups != null && a.AssetGroups.Id == Guid.Parse(collect["AssetGroupS"])).DefaultIfEmpty().ToList();
                }

            }
            if (newassset != null)
            {
                if (collect["Fromdate"] != "")
                {
                    var t1 = DateTime.Parse(collect["Fromdate"]);
                    if (t1 != DateTime.MinValue)
                    {
                        newassset = newassset.Where(a => a.Asset.DateUpdate > t1).ToList();
                    }
                }
                if (collect["Todate"] != "")
                {
                    var t2 = DateTime.Parse(collect["Todate"]);

                    if (t2 != DateTime.MinValue)
                    {
                        newassset = newassset.Where(a => a.Asset.DateUpdate < t2).ToList();
                    }
                }
            }
               
          
            return View(newassset);
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

        public async Task<IActionResult> Create(Guid? id)
        {
            var asset = new Assets();

            if (id.HasValue)
            {
                asset = await _context.Assets.FindAsync(id);
            }
            ViewData["Manufacturer"] = await _context.Manufacturers.DefaultIfEmpty().ToListAsync();
            ViewData["Unit"] = await _context.Units.DefaultIfEmpty().ToListAsync();
            var jt = (from a in _context.AssetTypes join b in _context.Assets on a equals b.Type
                      where b.Id == id
                      select new AssetsViewModel
                      {
                          Asset = b,
                          AssetType = a
                      }).FirstOrDefault();
            var type = _context.AssetTypes.Where(a => a == jt.AssetType).FirstOrDefault();
            ViewData["Type"] = type;
            ViewData["AssetGroup"] = await _context.AssetGroups.Where(a => a.AssetType == type).ToListAsync();
            return PartialView("_OrderPartial", asset);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid? id, [Bind("Name,MFG,Amount,Address,Reason,Place,Guarantee,DateUse,TechnicalData,Status,Note,Id,DateUpdate,UpdateBy,Wattage,WeightHandle,VehiclePlate,SeatNumber,BudgetSource,CareerSource,AidSource,AnotherSource")] Assets assets, IFormCollection collect)
        {
            ViewData["Manufacturer"] = await _context.Manufacturers.DefaultIfEmpty().ToListAsync();
            ViewData["Unit"] = await _context.Units.DefaultIfEmpty().ToListAsync();
            ViewData["AssetType"] = await _context.AssetTypes.DefaultIfEmpty().ToListAsync();
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            assets.UpdateBy =  _context.Users.Find(userId).FullName;
            assets.Manufacturer = await _context.Manufacturers.FindAsync(Guid.Parse(collect["Manufacturer"]));
            assets.Unit = await _context.Units.FindAsync(Guid.Parse(collect["Unit"]));
            assets.Type = await _context.AssetTypes.FindAsync(Guid.Parse(collect["AssetType"]));
            assets.WareHouse = await _context.WareHouse.FindAsync(Guid.Parse(collect["wareHouseID"]));
            assets.Price = assets.AidSource + assets.AnotherSource + assets.BudgetSource + assets.CareerSource;
            assets.AssetGroups = _context.AssetGroups.Find(Guid.Parse(collect["AssetGroup"]));
            CurrentSelected = Guid.Parse(collect["wareHouseID"]);
            
            if(collect["Code"]=="")
            {
                
            }
            else
            {
                assets.Code = collect["Code"];
            }
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
                        await _context.AddAsync(assets);
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
        public async Task<IActionResult> GenerateQr(Guid id)
        {
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

                                   where j3.Id.Equals(id)


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
            List<AssetQR> listQr = new List<AssetQR>();
            if(assetList != null)
            {
                foreach(var item in assetList)
                {
                    AssetQR temp = new AssetQR();
                    temp.AssetInfo = item;
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(item.Asset.Id.ToString(),
                    QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    temp.QRbitmap =  BitmapToBytes(qrCodeImage);
                    listQr.Add(temp);
                }
            }
            return PartialView("_QrGeneratePartial", listQr);
        }

        [Authorize]
        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
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
                                    }
                                    if (worksheet.Cells[i, 5].Value != null)
                                    {
                                        AssetTypes type = _context.AssetTypes.Where(a => a.AssetTypeName.ToLower().CompareTo(worksheet.Cells[i, 5].Value.ToString().Trim().ToLower()) == 0).DefaultIfEmpty().First();
                                        if (type != null)
                                        {
                                            asset.Type = type;
                                        }
                                    }
                                    if (worksheet.Cells[i, 6].Value != null)
                                    {
                                        Unit unit = _context.Units.Where(a => a.UnitName.ToLower().CompareTo(worksheet.Cells[i, 6].Value.ToString().Trim().ToLower()) == 0).DefaultIfEmpty().First();
                                        if (unit != null)
                                        {
                                            asset.Unit = unit;
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
            if (worksheet.Cells[1, 1].Value.ToString().Trim().Equals("Tên") &&
                 worksheet.Cells[1, 2].Value.ToString().Trim().Equals("Ngày sản xuất") &&
                 worksheet.Cells[1, 3].Value.ToString().Trim().Equals("Hạn bảo hành") &&
                 worksheet.Cells[1, 4].Value.ToString().Trim().Equals("Tên nhà sản xuất") &&
                 worksheet.Cells[1, 5].Value.ToString().Trim().Equals("Loại tài sản") &&
                 worksheet.Cells[1, 6].Value.ToString().Trim().Equals("Đơn vị tính") &&
                 worksheet.Cells[1, 7].Value.ToString().Trim().Equals("Số liệu kỹ thuật") &&
                 worksheet.Cells[1, 8].Value.ToString().Trim().Equals("Giá tiền") &&
                 worksheet.Cells[1, 9].Value.ToString().Trim().Equals("Tình trạng") &&
                 worksheet.Cells[1, 10].Value.ToString().Trim().Equals("Ghi chú") &&
                 worksheet.Cells[1, 11].Value.ToString().Trim().Equals("Đặt tại")
                )
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public JsonResult GetAssetGroup(string IdToSearch)
        {
            AssetTypes temp = _context.AssetTypes.Find(Guid.Parse(IdToSearch));
            var result = _context.AssetGroups.Where(a => a.AssetType.Equals(temp)).ToList();
            return Json(new { number = result.Count(), valueR = result }) ;
        }
    }
}
