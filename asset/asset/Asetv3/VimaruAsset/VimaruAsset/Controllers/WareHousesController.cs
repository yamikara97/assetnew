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
    public class WareHousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WareHousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WareHouse
        [Authorize]
        public async Task<IActionResult> Index()
        {
          
            var wareHouse = await (from a in _context.WareHouse
                             join b in _context.Department on a.department equals b into join1
                             from j1 in join1.DefaultIfEmpty()
                             
                             select new WareHouseUsersViewModel()
                             {
                                wareHouse = a,
                                department = j1
                             }
                             ).ToListAsync();
            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", wareHouse);
            }

            return View(wareHouse);
        }

        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var warehouse = new WareHouse();

            if (id.HasValue)
            {
                warehouse = await _context.WareHouse.FindAsync(id);
            }
            ViewData["Users"] = await _context.Department.DefaultIfEmpty().ToListAsync();
            return PartialView("_OrderPartial", warehouse);
        }


        // POST: WareHouse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid? id,[Bind("Name,WHStatus,Id,DateUpdate,UpdateBy,Address")] WareHouse wareHouse, IFormCollection collect)
        {

            wareHouse.UpdateBy = User.Identity.Name;
            wareHouse.department = _context.Department.Where(a => a.Id.Equals(collect["userSelected"].ToString())).FirstOrDefault();
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        _context.Update(wareHouse);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Updated Successfully";
                    }
                    else
                    {
                        await _context.AddAsync(wareHouse);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !WareHouseExists(wareHouse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["Users"] = await _context.Department.DefaultIfEmpty().ToListAsync();
            return PartialView("_OrderPartial", wareHouse);
        }
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wareHouse = await _context.WareHouse.FirstOrDefaultAsync(m => m.Id == id);
            if (wareHouse == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: wareHouse);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var wareHouse = await _context.WareHouse.FindAsync(id);

            if (wareHouse == null)
            {
                return NotFound();
            }
            try
            {
                _context.WareHouse.Remove(wareHouse);
                await _context.SaveChangesAsync();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return PartialView("_DeletePartial", wareHouse);
        }
        [Authorize]
        private bool WareHouseExists(Guid id)
        {
            return _context.WareHouse.Any(e => e.Id == id);
        }
    }
}
