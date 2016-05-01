using System;
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
    }
}