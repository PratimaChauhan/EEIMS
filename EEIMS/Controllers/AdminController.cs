using EEIMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

namespace EEIMS.Controllers
{
    public class AdminController : Controller
    {
        // Operations for: Admin

        public ActionResult AdminIndex()
        {
            return View();
        }   
        public async  Task<ActionResult> CreatRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            await roleManager.CreateAsync(new IdentityRole("Manager"));
            await roleManager.CreateAsync(new IdentityRole("Employee"));
            
            return new EmptyResult();
        }


        public ActionResult GetAdminRoleUsers()
        {
            var roleStore= new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var users = roleManager.FindByName("Admin").Users;

            return View();
        }

        //
        // GET: /UserId
        [HttpGet]
        public  ActionResult AssignRoleToEmployee()
        {
            populateRolesListItem();
            return View();
        }

        //
        // POST: /UserId
        [HttpPost]
        public async Task<ActionResult> AssignRoleToEmployee(AddRoleToUserViewModel model)
        {
            if (ModelState.IsValid)
            {   
                var context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    if (!await userManager.IsInRoleAsync(user.Id, model.Role))
                    {
                        var result = await userManager.AddToRoleAsync(user.Id, model.Role);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("AdminIndex", "Admin");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Failed to add the role to the user.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "User is already in the specified role.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User with the specified email not found.");
                }
            }
            populateRolesListItem();

            return View(model);
        }

        public void populateRolesListItem()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var roles = roleManager.Roles.ToList();
            var roleItems = roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            ViewBag.Roles = roleItems;
        }


    }
}