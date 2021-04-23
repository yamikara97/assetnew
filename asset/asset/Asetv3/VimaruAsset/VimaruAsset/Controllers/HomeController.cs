using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VimaruAsset.Data;
using VimaruAsset.Models;

namespace VimaruAsset.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;

        public SignInManager<ApplicationUser> SignInManager => _signInManager;

        public HomeController(
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


        public async Task<IActionResult> Index()
        {

            var l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-DAT").FirstOrDefault();
            var l2 = new AssetTypes();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Đất";
                l2.AssetTypeCode = "LTS-DAT";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-NCT").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Nhà/ Công trình xây dựng";
                l2.AssetTypeCode = "LTS-NCT";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-VKT").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Vật kiến trúc";
                l2.AssetTypeCode = "LTS-VKT";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-OTO").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Ô tô";
                l2.AssetTypeCode = "LTS-OTO";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-PT").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Phương tiện vận tải khác";
                l2.AssetTypeCode = "LTS-PT";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-MM").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Máy móc thiết bị";
                l2.AssetTypeCode = "LTS-MM";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-CS").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Cây lâu năm súc vật";
                l2.AssetTypeCode = "LTS-CS";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-K").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Tài sản cố định hữu hình khác";
                l2.AssetTypeCode = "LTS-K";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-VH").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Tài sản cố định vô hình";
                l2.AssetTypeCode = "LTS-VH";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            l2 = new AssetTypes();
            l1 = _context.AssetTypes.Where(a => a.AssetTypeCode == "LTS-CCDC").FirstOrDefault();
            if (l1 == null)
            {
                l2.Id = Guid.NewGuid();
                l2.AssetTypeName = "Công cụ dụng cụ";
                l2.AssetTypeCode = "LTS-CCDC";
                _context.AssetTypes.Add(l2);
                _context.SaveChanges();
            }
            //if (User.Identity.IsAuthenticated)
            //{
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //    var user = await _userManager.FindByIdAsync(userId);


                //    Guid idToFind = _context.UserRoles.Where(a => a.UserId.Equals(Guid.Parse(userId))).FirstOrDefault().RoleId;
                //    var role = _context.Roles.Find(idToFind);
                //    var x = (from a in _context.Users
                //             join b in _context.Department on a.Department equals b
                //             where a.Id == Guid.Parse(userId)
                //             select new AssetsViewModel
                //             {
                //                 User = a,
                //                 Department = b
                //             }
                //            ).FirstOrDefault();

                //    List<WareHouse> WareHouse = await _context.WareHouse.ToListAsync();
                //    if (role.Name != "Admin" && role.Name != "Manager" && role.Name != "ManagerApprove")
                //    {

                //        var departments = _context.Department.Where(a => a == x.Department).FirstOrDefault();
                //        WareHouse = await _context.WareHouse.Where(a => a.department == departments).ToListAsync();
                //        List<Department> d = _context.Department.Where(a => a.FatherID == departments.Code).ToList();
                //        foreach (var item in d)
                //        {
                //            var listW = _context.WareHouse.Where(a => a.department == item).ToList();
                //            foreach (var i in listW)
                //            {
                //                WareHouse.Add(i);
                //            }
                //        }
                //    }

                //    var assetList = await (from asset in _context.Assets
                //                           join assettype in _context.AssetTypes on asset.Type equals assettype into join1

                //                           from j1 in join1.DefaultIfEmpty()
                //                           join unit in _context.Units on asset.Unit equals unit into join2

                //                           from j2 in join2.DefaultIfEmpty()
                //                           join warehouse in _context.WareHouse on asset.WareHouse equals warehouse into join3

                //                           from j3 in join3.DefaultIfEmpty()
                //                           join manufact in _context.Manufacturers on asset.Manufacturer equals manufact into join4
                //                           from j4 in join4.DefaultIfEmpty()

                //                           join department in _context.Department on j3.department equals department into join5
                //                           from j5 in join5.DefaultIfEmpty()

                //                           select new AssetsViewModel()
                //                           {
                //                               Asset = asset,
                //                               AssetType = j1,
                //                               Unit = j2,
                //                               Warehouse = j3,
                //                               Manufacturer = j4,
                //                               Department = j5
                //                           }
                //                      ).ToListAsync();
                //    if (role.Name != "Admin" && role.Name != "Manager" && role.Name != "ManagerApprove")
                //    {
                //        assetList = assetList.Where(a => a.Department.Code == x.Department.Code || a.Department.FatherID == x.Department.Code).ToList();
                //    }


                //    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                //    {
                //        return PartialView("_DataTablePartial", assetList);
                //    }
                //    return View(assetList);
                //}
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
