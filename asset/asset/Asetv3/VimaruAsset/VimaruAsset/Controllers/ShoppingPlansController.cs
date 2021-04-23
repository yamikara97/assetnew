using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VimaruAsset.Data;
using VimaruAsset.Models;

namespace VimaruAsset.Controllers
{
    public class ShoppingPlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingPlansController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: ShoppingPlans
        public async Task<IActionResult> Index()
        {

            var shoppingPlant = await _context.ShoppingPlan.ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", shoppingPlant);
            }
            return View(shoppingPlant);
        }
        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var shoppingPlant = new ShoppingPlan();
            List<AssetPlantViewmodel> planAssets = new List<AssetPlantViewmodel>();
            if (id.HasValue)
            {
                shoppingPlant = await _context.ShoppingPlan.FindAsync(id);
                planAssets = (from a in _context.Units
                              join b in _context.PlanAsset on a equals b.Unit into join1
                              from j1 in join1.DefaultIfEmpty() 
                              join c in _context.AssetTypes on j1.Types equals c into join2
                              from j2 in join2.DefaultIfEmpty()
                              where j1.PlanId.Equals(shoppingPlant.Id)
                              select new AssetPlantViewmodel
                              {
                                  AssetTypes = j2,
                                  PlanAssets = j1,
                                  Unit = a
                              }
                              ).ToList();
            }
            ViewData["ListDepartment"] = await _context.Department.DefaultIfEmpty().ToListAsync();
            ViewData["Unit"] = await _context.Units.DefaultIfEmpty().ToListAsync();
            ViewData["AssetType"] = await _context.AssetTypes.DefaultIfEmpty().ToListAsync();
            ViewData["ListAsset"] = planAssets;
            return PartialView("_OrderPartial", shoppingPlant);
        }
        // POST: ShoppingPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid? id, [Bind("Name,Year,Content,Id,DateUpdate,UpdateBy")] ShoppingPlan shoppingPlan, IFormCollection collect)
        {
            ViewData["Unit"] = await _context.Units.DefaultIfEmpty().ToListAsync();
            ViewData["AssetType"] = await _context.AssetTypes.DefaultIfEmpty().ToListAsync();
            ViewData["ListDepartment"] = await _context.Department.DefaultIfEmpty().ToListAsync();
            List<AssetPlantViewmodel> planAssets = new List<AssetPlantViewmodel>();
            if (collect["Phongban"] != "")
            {
                shoppingPlan.Phongban = Guid.Parse(collect["Phongban"]);
            }
            planAssets = (from a in _context.Units
                            join b in _context.PlanAsset on a equals b.Unit into join1
                            from j1 in join1.DefaultIfEmpty()
                            join c in _context.AssetTypes on j1.Types equals c into join2
                            from j2 in join2.DefaultIfEmpty()
                            where j1.PlanId.Equals(shoppingPlan.Id)
                            select new AssetPlantViewmodel
                            {
                                AssetTypes = j2,
                                PlanAssets = j1,
                                Unit = a
                            }
                            ).ToList();
            ViewData["ListAsset"] = planAssets;
            if (ModelState.IsValid)
            {
                try
                {
                    shoppingPlan.UpdateBy = User.Identity.Name;
                    if (id.HasValue)
                    {
                        foreach (var item in _context.PlanAsset)
                        {
                            if (item != null && item.PlanId == id)
                            {
                                _context.PlanAsset.Remove(item);
                            }
                        }
                        _context.Update(shoppingPlan);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Sửa thành công";
                    }
                    else
                    {
                        await _context.AddAsync(shoppingPlan);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Thêm thành công";
                    }
                   
                    int Lenght = int.Parse(collect["countingValue"]);
                    for (int i = 1; i <= Lenght; i++)
                    {
                        PlanAssets temp = new PlanAssets();
                        temp.Id = Guid.NewGuid();
                        temp.Name = collect["na" + i];
                        temp.Types = _context.AssetTypes.Find(Guid.Parse(collect["ty" + i]));
                        temp.Method = collect["pt" + i];
                        temp.Unit = _context.Units.Find(Guid.Parse(collect["dv" + i]));
                        temp.Describe = collect["mt" + i];
                        temp.TimeExpected = DateTime.Parse(collect["tg" + i]);
                        temp.AmountExpected = int.Parse(collect["sl" + i]);
                        temp.PriceExpected = double.Parse(collect["dg" + i]);
                        temp.UpdateBy = User.Identity.Name;
                        if (collect["ht" + i] == "Chaohang") { temp.BuyingMethod = PlanAssets.BuyingMethods.Chaohang; }
                        if (collect["ht" + i] == "Chidinhthau") { temp.BuyingMethod = PlanAssets.BuyingMethods.Chidinhthau; }
                        if (collect["ht" + i] == "Dauthau") { temp.BuyingMethod = PlanAssets.BuyingMethods.Dauthau; }
                        if (collect["ht" + i] == "Muasamtructiep") { temp.BuyingMethod = PlanAssets.BuyingMethods.Muasamtructiep; }
                        temp.Estimate = double.Parse(collect["dt" + i]);
                        temp.Note = collect["gc" + i];
                        if (id.HasValue) { temp.PlanId = Guid.Parse(id.ToString()); }
                        else { temp.PlanId = shoppingPlan.Id; }
                        
                        _context.PlanAsset.Add(temp);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !ShoppingPlanExists(shoppingPlan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", shoppingPlan);
        }


        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.ShoppingPlan.FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: plan);
        }

        // POST: ShoppingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var plan = await _context.ShoppingPlan.FindAsync(id);

            if (plan == null)
            {
                return NotFound();
            }

            try
            {
                foreach (var item in _context.PlanAsset)
                {
                    if (item != null && item.PlanId.Equals(plan.Id)) _context.PlanAsset.Remove(item);
                }
                _context.ShoppingPlan.Remove(plan);
                await _context.SaveChangesAsync();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return PartialView("_DeletePartial", plan);
        }

        private bool ShoppingPlanExists(Guid id)
        {
            return _context.ShoppingPlan.Any(e => e.Id == id);
        }
        [HttpGet]
        [Authorize]
        public async Task<JsonResult> getRowInfo()
        {
            List<AssetTypes> listAsset = await _context.AssetTypes.ToListAsync();
            List<Unit> listUnit = await _context.Units.ToListAsync();
            return Json(new { listA = listAsset,listU = listUnit });
        }
    }
}
