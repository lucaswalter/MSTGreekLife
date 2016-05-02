using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSTGreekLife.Models
{
    public class CreatePartyViewModel
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime Time { get; set; }
        public Address Location { get; set; }


        public SelectList ListOfGreekHouses { get; set; }
        public int SelectedHouseId { get; set; }
    }
}