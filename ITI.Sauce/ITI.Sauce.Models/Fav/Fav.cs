using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Fav
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int Recipe_ID { get; set; }

        public virtual Users User { get; set; }   
        public virtual Recipe Recipe { get; set; }
        

    }
}
