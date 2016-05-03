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
            var rollaSchool = new SchoolModel {SchoolName = "Missouri S&T"};

            context.Schools.Add(rollaSchool);
            context.SaveChanges();

        }
    }
}

