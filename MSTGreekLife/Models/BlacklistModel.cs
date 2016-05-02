using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSTGreekLife.Models
{
    public class BlacklistModel
    {
        public int Id { get; set; }
        public virtual StudentModel Student { get; set; }
        public virtual GreekHouseModel GreekHouse { get; set; }
        public string Reason { get; set; }
    }
}