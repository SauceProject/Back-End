using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;


namespace ITI.Sauce.ViewModels
{
    public static partial class FavExtentions
    {
        public static FavoriteViewModel ToViewModel(this Fav model)
        {

            return new FavoriteViewModel
            {
                Fav_ID = model.ID,
                UserID = model.UserID,
                Recipe_ID = model.Recipe_ID,



            };
        }
        public static FavEditViewModelExtentions ToEditViewModel(this FavoriteViewModel model)
        {


            return new FavEditViewModelExtentions()
            {

                Fav_ID = model.Fav_ID,
                UserID = model.UserID,
                Recipe_ID = model.Recipe_ID,



            };
        }








        //public class FavViewModel
        //{
        //    public int Fav_ID { get; set; }
        //    public string UserID { get; set; }
        //    public int Recipe_ID { get; set; }
        //}
    }
}
