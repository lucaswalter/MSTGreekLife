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
            /** Create Missouri S&T **/
            var rollaSchool = new SchoolModel { SchoolName = "Missouri S&T" };

            context.Schools.Add(rollaSchool);
            context.SaveChanges();

            /** Create Greek Houses **/
            /*var kappaSigma = new GreekHouseModel
            {
                HouseName = "Kappa Sigma",
                HouseLetters = "KΣ",
                HouseAddress = { Street = "1701 White Columns Dr", City = "Rolla", State = "MO", ZIP = 65401 }
            };

            
            rollaSchool.GreekHouses.Add(kappaSigma);
            context.Schools.AddOrUpdate(rollaSchool);
            context.SaveChanges();

            context.GreekHouses.Add(kappaSigma);
            context.SaveChanges();*/

            /*var sigEp = new GreekHouseModel
            {
                HouseName = "Sigma Phi Epsilon",
                HouseLetters = "ΣΦΕ",
                HouseAddress = { Street = "801 North Park St", City = "Rolla", State = "MO", ZIP = 65401 },
                Parties = new List<PartyModel>()
            };*/



            /** Create Students **/
            /*var students = new List<StudentModel>
            {
                new StudentModel
                {
                    StudentID = 12401244,
                    Name = {FirstName = "Lucas", LastName = "Wyland"},
                    Age = 20,
                    GreekHouse = kappaSigma,
                    Guests = new List<GuestModel>()
                }
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();*/
        }

        // TODO: Possibly Add Role Generation In Migrations
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
