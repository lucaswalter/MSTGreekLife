using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSTGreekLife.Models
{
    public class GreekHouseModel
    {
        public int Id { get; set; }
        public string HouseName { get; set; }
        public string HouseLetters { get; set; }
        public Address HouseAddress { get; set; }

        // School That A House Belongs Too
        // public virtual SchoolModel School { get; set; }

        // Parties That A Greek House Schedules & Holds
        public virtual ICollection<PartyModel> Parties { get; set; }
    }
}