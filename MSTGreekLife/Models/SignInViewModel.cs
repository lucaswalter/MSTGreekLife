using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSTGreekLife.Models
{
    public class SignInViewModel
    {
        public virtual PartyModel Party { get; set; }
        public int PartyID { get; set; }
        public int StudentId { get; set; }
        public GuestModel Guest1 { get; set; }
        public GuestModel Guest2 { get; set; }
    }
}