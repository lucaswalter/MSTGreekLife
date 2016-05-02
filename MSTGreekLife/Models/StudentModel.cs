using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSTGreekLife.Models
{
    public class StudentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        public Name Name { get; set; }
        public int Age { get; set; }

        // House The Student Is Affiliated With 
        public virtual GreekHouseModel GreekHouse { get; set; }

        public virtual ICollection<PartyModel> PartiesAttended { get; set; }

        // Collection Of The Two Guests A Student May Bring
        public virtual ICollection<GuestModel> Guests { get; set; }
    }
}