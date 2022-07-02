using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string NameEN {get; set; }
        public string NameAR { get; set; }

        public bool IsDeleted { get; set; }
        public List<Recipe> Recipes { get; set; }

    }
}
