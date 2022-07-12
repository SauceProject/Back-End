using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public string Comment { get; set;}
        public int RatingValue { get; set; }
        public int RecipeID { get; set; }
        public string UserID { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Users User { get; set; }



    }
}
