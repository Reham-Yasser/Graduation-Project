using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Identity
{
   public  class Address
    {

        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public AppUser User { get; set; }



    }
}
