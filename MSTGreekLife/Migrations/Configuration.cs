using System.Collections.Generic;
using MSTGreekLife.Models;

namespace MSTGreekLife.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MSTGreekLife.DAL.GreekLifeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MSTGreekLife.DAL.GreekLifeContext context)
        {
            /*var students = new List<StudentModel>
            {
            new StudentModel { Name = {FirstName = "Lucas", LastName = "Wyland"}, Age = 20, StudentID = 12401244, GreekHouse = {HouseName = "Kappa Sigma"}, Guests = new List<GuestModel>()}

            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();*/
        }
    }
}
