using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using System.ComponentModel.DataAnnotations;


namespace ITI.Sauce.ViewModels
{
    public static partial class FavExtentions
    {


        public static Fav ToModel(this FavEditViewModelExtentions model)
        {
            return new Fav
            {

                ID = model.Fav_ID,
                UserID = model.UserID,
                Recipe_ID = model.Recipe_ID,
            };
        }
    }
    public class FavEditViewModelExtentions
    {
        [Required]
        public int Fav_ID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public int Recipe_ID { get; set; }
     
    }
}

