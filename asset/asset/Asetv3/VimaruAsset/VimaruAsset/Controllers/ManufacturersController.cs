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
    public class ManufacturersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManufacturersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manufacturers
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var manufacturer = await _context.Manufacturers.ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", manufacturer);
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Details/5
        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var manufacturer = new Manufacturer();

            if (id.HasValue)
            {
                manufacturer = await _context.Manufacturers.FindAsync(id);
            }

            return PartialView("_OrderPartial", manufacturer);
        }


        // POST: Manufacturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid? id, [Bind("Name,PhoneNo,Address,Note,Id,DateUpdate,UpdateBy")] Manufacturer manufacturer)
        {
            manufacturer.UpdateBy = User.Identity.Name;
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        _context.Update(manufacturer);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Sửa thành công";
                    }
                    else
                    {
                        await _context.AddAsync(manufacturer);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Thêm thành công ";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !ManufacturerExists(manufacturer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", manufacturer);
        }
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: manufacturer);
        }
        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            try
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return PartialView("_DeletePartial", manufacturer);
        }
        [Authorize]
        private bool ManufacturerExists(Guid id)
        {
            return _context.Manufacturers.Any(e => e.Id == id);
        }
    }
}
