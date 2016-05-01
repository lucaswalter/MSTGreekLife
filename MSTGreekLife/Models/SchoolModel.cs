using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSTGreekLife.Models
{
    public class SchoolModel
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }

        // Greek Houses That Exist At The Given School
        public virtual ICollection<GreekHouseModel> GreekHouses { get; set; }      
    }
}