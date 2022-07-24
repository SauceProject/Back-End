using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;

namespace ITI.Sauce.Repository
{
   public class Recipe_IngredientRepository :GeneralRepository<RecipeIngredient>
    {
        private readonly IngredientRepository ingredientRepository;
        public Recipe_IngredientRepository(DBContext _Context, IngredientRepository _ingredientRepository) : base(_Context)
        {
            ingredientRepository = _ingredientRepository;
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
        public List<IngredientViewModel> GetIng(int RecipeId)
        {
            List<IngredientViewModel> list = new List<IngredientViewModel>();
            var res =  base.GetList().Where(i => i.RecipeID == RecipeId).ToList();
            foreach (var item in res)
            {
                list.Add(ingredientRepository.GetOne(item.IngredientID));
            }
            return list;

        }

    }
}
