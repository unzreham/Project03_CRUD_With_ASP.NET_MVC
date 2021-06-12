using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KSA_s_Finest_Sightseeing_Tours.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string email { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string password { get; set; }

        public ICollection<Tour> Tours { get; set; }



    }
}
