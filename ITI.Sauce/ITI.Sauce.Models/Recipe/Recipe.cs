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
        public virtual Category Category { get; set; }
        public virtual List<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual List<Fav> Favs { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<OrderList> OrderList { get; set; }
        public virtual int? ResturantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }


    }
}
