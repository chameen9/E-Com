using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Com.Data;
using E_Com.Models.Data;
using E_Com.Business.Interfaces;
using E_Com.Business.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace E_Com.Controllers.Admin
{
    public class ManageUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IUserService _userService;
        public IUserTypeService _userTypeService;

        public ManageUsersController(ApplicationDbContext context, IUserService userService, IUserTypeService userTypeService)
        {
            _context = context;
            _userService = userService;
            _userTypeService = userTypeService;
        }

        // GET: ManageUsers
        public async Task<IActionResult> Index()
        {
            var users = _userService.GetAllUsers();
            ViewData["UsersList"]= users;
            return View(users);
        }

        // GET: ManageUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.UserTypes)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: ManageUsers/Create
        public IActionResult Create()
        {
            ViewData["UserTypesList"] = _userTypeService.GetAllUserTypes();
            return View();
        }

        // POST: ManageUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            var model = _userService.CreateUser(user);
            if(model != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ManageUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["UserTypesList"] = _userTypeService.GetAllUserTypes();

            var user = _userService.GetUserById(id);

            ViewData["User"] = user;

            return View(user);
        }

        // POST: ManageUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string UserId, string Username, string Paswword, int TypeId, User user)
        {
            if (UserId == null)
            {
                NotFound();
            }
            else
            {
                _userService.UpdateUser(UserId,Username, Paswword, TypeId);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: ManageUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.UserTypes)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: ManageUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
          return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
