using System.Collections.Generic;
using MSTGreekLife.Models;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MSTGreekLife.DAL;

namespace MSTGreekLife.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<MSTGreekLife.DAL.GreekLifeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MSTGreekLife.DAL.GreekLifeContext context)
        {
            // Create Roles & User Accounts
            // InitializeIdentityForEF(context);

            var schools = new List<SchoolModel>
            {
                new SchoolModel {SchoolName = "Missouri S&T", Id = 1}
            };

            schools.ForEach(s => context.Schools.Add(s));
            context.SaveChanges();

        }

        public static void InitializeIdentityForEF(GreekLifeContext db)
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            // Create Roles
            var IFC = roleManager.FindByName("IFC");
            if (IFC == null)
            {
                IFC = new IdentityRole("IFC");
                roleManager.Create(IFC);
            }

            var GREEK = roleManager.FindByName("GREEK");
            if (GREEK == null)
            {
                GREEK = new IdentityRole("GreekHouse");
                roleManager.Create(GREEK);
            }

            // Create Users
            var user1 = userManager.FindByName("IFC");
            if (user1 == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "IFC",
                    Email = "ifc@mst.edu",
                };
                userManager.Create(newUser, "!Mustan69");
                userManager.SetLockoutEnabled(newUser.Id, false);
                userManager.AddToRole(newUser.Id, "IFC");
            }

            var user2 = userManager.FindByName("KappaSigma");
            if (user2 == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "KappaSigma",
                    Email = "kappasig@mst.edu",
                };
                userManager.Create(newUser, "!Mustan69");
                userManager.SetLockoutEnabled(newUser.Id, false);
                userManager.AddToRole(newUser.Id, "GREEK");
            }
        }
    }
}
