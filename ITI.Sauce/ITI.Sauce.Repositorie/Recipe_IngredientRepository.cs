using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.Repository
{
   public class Recipe_IngredientRepository :GeneralRepository<RecipeIngredient>
    {
        public Recipe_IngredientRepository(DBContext _Context) : base(_Context)
        {

        }
        public RecipeIngredient Add(int RecipeId, int Ingredient)
        {
            RecipeIngredient RI = new RecipeIngredient()
            {
                RecipeID = RecipeId,
               IngredientID = Ingredient
            };
            return base.Add(RI).Entity;

       

    }
    public List<RecipeIngredient> Get(int RecipeId)
    {

        return base.GetList().Where(i => i.RecipeID == RecipeId).ToList();

    }

}
}
