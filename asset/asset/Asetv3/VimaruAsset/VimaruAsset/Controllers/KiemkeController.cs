using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
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
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using QRCoder;
using VimaruAsset.Data;
using VimaruAsset.Models;


namespace VimaruAsset.Controllers
{
    public class KiemkeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public KiemkeController(
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
        public IActionResult Index()
        {
            Privacy prv = new Privacy();
            if (DateTime.Now > prv.DateEnd1)
            {
                return NotFound();
            }
            var Phongban = _context.Department.ToList();
            var listPhongban = new List<KiemkeViewModel>();

            foreach (var item in Phongban)
            {
                int count = 0;

                var book = _context.WareHouse.Where(a => a.department == item).ToList();
                count += book == null ? 0 : book.Count;
                var temp = new KiemkeViewModel();
                temp.AssetCount = count;
                temp.Department = item;
                listPhongban.Add(temp);
            }
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", listPhongban);
            }
            return View(listPhongban);
        }

        [Authorize]
        public IActionResult Create()
        {
            return PartialView("_OrderPartial");
        }

        public class fileByte
        {
           public string name { get; set; }
            public byte[] file { get; set; }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(IFormCollection collect)
        {
            List<fileByte> lb = new List<fileByte>();
            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    if (collect["fromdate"] != "" && collect["todate"] != "" && collect["Year"] != "")
                    {
                        int month1 = int.Parse(collect["fromdate"]);
                        int month2 = int.Parse(collect["todate"]);
                        int year = int.Parse(collect["Year"]);
                        if (month1 > month2)
                        {
                            return NotFound();
                        }
                        var listPB = new List<AssetsViewModel>();
                        var listPB1 = (from asset in _context.Assets
                                      join assettype in _context.AssetTypes on asset.Type equals assettype into join1

                                      from j1 in join1.DefaultIfEmpty()
                                      join unit in _context.Units on asset.Unit equals unit into join2

                                      from j2 in join2.DefaultIfEmpty()
                                      join warehouse in _context.WareHouse on asset.WareHouse equals warehouse into join3

                                      from j3 in join3.DefaultIfEmpty()
                                      join manufact in _context.Manufacturers on asset.Manufacturer equals manufact into join4

                                      from j4 in join4.DefaultIfEmpty()
                                      join user1 in _context.Department on j3.department equals user1 into join5

                                      from j6 in join5.DefaultIfEmpty()

                                      join assetgroup in _context.AssetGroups on asset.AssetGroups equals assetgroup into join7
                                      from j7 in join7.DefaultIfEmpty()

                                      where asset.DateUse.Year == year && asset.DateUse.Month <= month2 && asset.DateUse.Month >= month1 && j6 != null

                                     

                                      select new AssetsViewModel()
                                      {
                                          Asset = asset,
                                          AssetType = j1,
                                          Unit = j2,
                                          Warehouse = j3,
                                          Manufacturer = j4,
                                          Department = j6,
                                          AssetGroups = j7
                                      }
                                      ).ToList();
                        foreach (var item  in listPB1)
                        {
                            var check = listPB.Where(a => a.Asset.identify == item.Asset.identify).FirstOrDefault();
                            if ( check != null )
                            {
                                listPB.Where(a => a.Asset.identify == item.Asset.identify).FirstOrDefault().Asset.Amount += item.Asset.Amount;
                                listPB.Where(a => a.Asset.identify == item.Asset.identify).FirstOrDefault().Asset.Price += item.Asset.Price;
                            }
                            else 
                            {
                                listPB.Add(item);
                            }
                        }
                        if (collect["val"] != "")
                        {
                            string[] str = collect["val"].ToString().Split("**");
                            for (int i = 0; i < str.Length - 1; i++)
                            {
                               
                                var department = _context.Department.Find(Guid.Parse(str[i]));
                                var listcur = listPB.Where(a => a.Department.Code.Contains(department.Code)).ToList();

                                string url = Path.Combine(_env.WebRootPath, "DataSource", "Maukiemke.xlsx");
                                var filemau = System.IO.File.ReadAllBytes(url);
                                string file = Path.Combine(_env.WebRootPath, "DataReturn", "Kiemke" + Guid.NewGuid() + ".xlsx");
                                System.IO.File.WriteAllBytes(file, filemau);
                                var fileref2 = System.IO.File.ReadAllBytes(file);
                                using (ExcelPackage package = new ExcelPackage())
                                {
                                    using (FileStream stream = new FileStream(file, FileMode.Open))
                                    {
                                        package.Load(stream);
                                        var ws = package.Workbook.Worksheets[0];
                                        for (int c = 8; c < listcur.Count() + 8; c++)
                                        {
                                          
                                            ws.Row(c).Height = 30;
                                            ws.Cells[c, 1].Value = (c-7).ToString();
                                            ws.Cells[c, 2].Value = listcur[c - 8].Asset.Name;
                                            ws.Cells[c, 3].Value = listcur[c - 8].Asset.Code;
                                            ws.Cells[c, 4].Value = listcur[c - 8].Department.Code == null ? "" : listcur[c - 8].Department.Code;
                                            ws.Cells[c, 5].Value = listcur[c - 8].Department.Name;
                                            ws.Cells[c, 10].Value = listcur[c - 8].Asset.Amount.ToString();
                                            ws.Cells[c, 11].Value = listcur[c - 8].Asset.Price.ToString("#.###");
                                            var timec = DateTime.Now - listcur[c - 8].Asset.DateUse;
                                            if(timec.TotalDays <= 0)
                                            {
                                                ws.Cells[c, 12].Value = listcur[c - 8].Asset.Price.ToString("#.###");
                                            }
                                            else if(DateTime.Now.Year - listcur[c - 8].Asset.DateUse.Year >0)
                                            {

                                                var atrophy =  listcur[c - 8].AssetGroups == null ? 0 : listcur[c - 8].AssetGroups.AtrophyPercent;
                                                var valueLeft = listcur[c - 8].Asset.Price - (listcur[c - 8].Asset.Price / (DateTime.Now.Year - listcur[c - 8].Asset.DateUse.Year));
                                                ws.Cells[c, 12].Value = valueLeft.ToString("#.###");
                                            }
                                            else
                                            {
                                                ws.Cells[c, 12].Value = listcur[c - 8].Asset.Price.ToString("#.###");
                                            }
                                            
                                        }
                                        Byte[] bin = package.GetAsByteArray();
                                        string fn = department.Name + "-TSCĐ-"+DateTime.Now.ToString().Replace("/","-")+".xlsx";
                                        fileByte fb = new fileByte();
                                        fb.file = bin;
                                        fb.name = fn;
                                        lb.Add(fb);
                                    }
                                }
                            }
                        }
                        foreach (var item in lb)
                        {
                            var zipEntry = archive.CreateEntry(item.name, System.IO.Compression.CompressionLevel.Optimal);
                            using (var zipStream = zipEntry.Open())
                            {
                                zipStream.Write(item.file, 0, item.file.Length);
                                zipStream.Close();
                            }
                           
                        }
                        
                       
                    }
                    archive.Dispose();
                    return File(ms.ToArray(), "application/zip", DateTime.Now.Day+"-"+ DateTime.Now.Month + "-"+DateTime.Now.Year+"-Kiem_ke_tai_san.zip");
                }
            }
        }
    }
}