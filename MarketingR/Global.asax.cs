using MarketingR.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MarketingR
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CreateSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("Rmaury99900@gmail.com");
            if(user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "Rmaury99900@gmail.com",
                    Email= "Rmaury99900@gmail.com"
                };
                userManager.Create(user, "Maury123.");
            }
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!roleManager.RoleExists("Administrador"))
            {
                roleManager.Create(new IdentityRole("Administrador"));
            }
            if (!roleManager.RoleExists("Cliente"))
            {
                roleManager.Create(new IdentityRole("Cliente"));
            }
            if (!roleManager.RoleExists("Empleado"))
            {
                roleManager.Create(new IdentityRole("Empleado"));
            }
        }
    }
}
