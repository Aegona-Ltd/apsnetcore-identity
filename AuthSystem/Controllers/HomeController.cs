using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthSystem.Models;
using AuthSystem.Data;
using Microsoft.AspNetCore.Authorization;
using AuthSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuthSystem.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly AuthDbContext auth;
        public HomeController(AuthDbContext auth, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.auth = auth;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin, UserList")]
        public IActionResult Index()
        {
            List<ApplicationUser> users = auth.Users.ToList();
            List<UserRoleViewModel> userRoles = new List<UserRoleViewModel>();
            users.ForEach(x =>
            {
                UserRoleViewModel a = new UserRoleViewModel
                {
                    user = new ApplicationUser
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Address = x.Address,
                        Email = x.Email,
                        Id = x.Id
                    },
                    roles = _userManager.GetRolesAsync(x).Result.ToList()
                };
                userRoles.Add(a);
            });
            return View(userRoles);
        }
        //Edit role
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            //
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            // GetRolesAsync returns the list of user Roles
            List<string> userRoles = _userManager.GetRolesAsync(user).Result.ToList();

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = userRoles,
                Role = userRoles.ToString(),
                Rolesss = new SelectList(roles)
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    _ = await _userManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        //Edit user
        [Authorize(Roles = "Admin, UserList")]
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Address = model.Address;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        //Delete user
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View();
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Index");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //Remove role
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> RemoveRole(string id)
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            //
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            // GetRolesAsync returns the list of user Roles
            List<string> userRoles = _userManager.GetRolesAsync(user).Result.ToList();

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = userRoles,
                Role = userRoles.ToString(),
                Rolesss = new SelectList(roles)
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRole(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    _ = await _userManager.RemoveFromRoleAsync(user, model.Role);
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
    }
}
