using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KSA_s_Finest_Sightseeing_Tours.Models
{
    public class Booking
    {
        [Key]
        public int id { get; set; }
        public int adult { get; set; }
        public int child { get; set; }
        public int total { get; set; }
        [Column(TypeName = "varchar(50)")]

        public string  firstName { get; set; }
        [Column(TypeName = "varchar(50)")]

        public string LastName { get; set; }






    }
}
