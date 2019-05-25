using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Models
{
    public class Soldier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        
        [NotMapped]
        public int serial { get; set; }
    }
}
