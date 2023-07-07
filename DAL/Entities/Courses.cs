using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public  class Courses : BaseEnities
    {
       public string Course_name { get; set; }

        public string Course_type { get; set; }

        public string Course_link { get; set; } 

        public int Course_level { get; set; }
        [ForeignKey("Tracks")]

        public int Track_id { get; set; }

         public  Tracks Tracks { get; set; }

      
    





    }
}
