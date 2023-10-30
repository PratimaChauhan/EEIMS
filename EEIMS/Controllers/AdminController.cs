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

            return View();
        }

        //
        // GET: /UserId
        public  ActionResult AssignRoleToEmployee(string id)
        {
            var applicationUserContext = new ApplicationDbContext();
            var userStore =  new UserStore<ApplicationUser>(applicationUserContext);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user =  userManager.FindById(id);
            userManager.AddToRole(user.Id, "Employee");
            
            return new EmptyResult();
        }


    }
}