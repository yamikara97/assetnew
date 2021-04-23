using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VimaruAsset.Data;
using VimaruAsset.Models;

namespace Vimaru.Asset.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        public ApplicationUserController(
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

        // GET: ApplicationUsers
        [Authorize]
        public IActionResult Index()
        {
            Privacy prv = new Privacy();
            if (DateTime.Now > prv.DateEnd2)
            {
                return NotFound();
            }
            var userList = (from user in _context.Users
                            join userrole in _context.UserRoles on user.Id equals userrole.UserId into join1
                            from j1 in join1.DefaultIfEmpty()

                            join role in _context.Roles on j1.RoleId equals role.Id into join2
                            from j2 in join2.DefaultIfEmpty()

                            join department in _context.Department on user.Department equals department into join3
                            from j3 in join3.DefaultIfEmpty()
                            select new UserViewModel()
                            {
                                user = user,
                                role = j2,
                                department = j3
                            }).ToList();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", userList);
            }

            return View(userList);
        }
        [Authorize]
        public async Task<IActionResult> AddRole(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.UserID = id;
            ViewBag.Roles = await _context.Roles.ToListAsync();
            return PartialView("_AddRolePartial");
        }
        [HttpPost, ActionName("AddRole")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddRole(IFormCollection Info)
        {
            
            try
            {
                IdentityUserRole<Guid> role = new IdentityUserRole<Guid>();
                role.RoleId = Guid.Parse(Info["Role"]);
                role.UserId = Guid.Parse(Info["Id"]);
                IdentityUserRole<Guid> temp = _context.UserRoles.Where(m => m.UserId == Guid.Parse(Info["Id"])).FirstOrDefault();
                if (temp != null)
                {
                    _context.UserRoles.Remove(temp);
                    await _context.SaveChangesAsync();
                }
                _context.UserRoles.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        { 
            var user = new ApplicationUser();
            if (id.HasValue)
            {
                user = await _context.Users.FindAsync(id);
            }
            ViewData["Department"] = await _context.Department.ToListAsync();
            return PartialView("_OrderPartial", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Guid id, [Bind("FullName,IsAdmin,DateCreate,LastOnline,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser,IFormCollection collect)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    applicationUser.Department = _context.Department.Find(Guid.Parse(collect["Department"]));
                    var user = new ApplicationUser();
                    user = await _context.Users.FindAsync(id);
                    if(user != null)
                    {
                        user.FullName = applicationUser.FullName;
                        user.PhoneNumber = applicationUser.PhoneNumber;
                        user.Department = applicationUser.Department;
                        _context.Users.Update(user);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }
        [Authorize]
        public async Task<IActionResult> ResetPassword(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Email = user.Email;

            return PartialView("_ResetPassword", model: resetPassword);

        }

        [HttpPost, ActionName("ResetPassword")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ResetPassword(Guid? id, [Bind("Email,Password,ConfirmPassword")] ResetPassword resetPassword)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(resetPassword.Email);
                    if (user == null || id != user.Id)
                    {
                        return NotFound();
                    }
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                    var result = await _userManager.ResetPasswordAsync(user, Code, resetPassword.Password);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return PartialView("_ResetPassword", resetPassword);
        }
        // GET: ApplicationUsers/Edit/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return PartialView("_DeletePartial", model: user);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _context.Users.Remove(user);
                foreach(var temp in _context.UserRoles) {
                    if (temp.UserId == id)
                        _context.UserRoles.Remove(temp);
                }
                await _context.SaveChangesAsync();

                TempData["Notifications"] = "Xóa thành công";
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return PartialView("_DeletePartial", user);
        }
        [Authorize]
        private bool ApplicationUserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
