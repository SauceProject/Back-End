using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class RecipeIngredient
    {
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public int Qty { get; set; }
        public string Type { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
