using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VimaruAsset.Data;
using VimaruAsset.Models;

namespace VimaruAsset.Controllers
{
    public class AssetTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetTypesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: AssetTypes
        public async Task<IActionResult> Index()
        {
            var assetType = await _context.AssetTypes.ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", assetType);
            }
            return View(assetType);
        }

        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var assetType = new AssetTypes();

            if (id.HasValue)
            {
                assetType = await _context.AssetTypes.FindAsync(id);
            }

            return PartialView("_OrderPartial", assetType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid? id,[Bind("AssetTypeName,AssetTypeCode,Detail,Id,DateUpdate,UpdateBy")] AssetTypes assetTypes)
        {
            assetTypes.UpdateBy = User.Identity.Name;
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        _context.Update(assetTypes);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Updated Successfully";
                    }
                    else
                    {
                        await _context.AddAsync(assetTypes);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !AssetTypesExists(assetTypes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", assetTypes);
        }
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assettypes = await _context.AssetTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (assettypes == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: assettypes);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var assettypes = await _context.AssetTypes.FindAsync(id);

            if (assettypes == null)
            {
                return NotFound();
            }
            try
            {
                _context.AssetTypes.Remove(assettypes);
                await _context.SaveChangesAsync();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return PartialView("_DeletePartial", assettypes);
        }
        private bool AssetTypesExists(Guid id)
        {
            return _context.AssetTypes.Any(e => e.Id == id);
        }
    }
}
