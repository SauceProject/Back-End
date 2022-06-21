using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int CategoryID { get; set; }
        public string Details { get; set; }
        public int GoodFor { get; set; }
        public float Price { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<Fav> Favs { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Order> Orders { get; set; }


    }
}
