using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSTGreekLife.Models
{
    public class PartyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime Time { get; set; }
        public Address Location { get; set; }

        // Hosting House
        public virtual GreekHouseModel HostingHouse { get; set; }

        // Student Attendees
        public virtual ICollection<StudentModel> Students { get; set; }
    }
}