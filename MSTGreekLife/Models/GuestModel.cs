using System.ComponentModel.DataAnnotations;

namespace MSTGreekLife.Models
{
    public class GuestModel
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public int Age { get; set; }

        // Student Who Signed This Guest In
        public virtual StudentModel Student { get; set; }
    }
}