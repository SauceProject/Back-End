using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ITI.Sauce.Models
{
    public class Users : IdentityUser
    {
       
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime registerDate { get; set; }
        public bool IsDelete { get; set; }
        public List<Fav> favs { get; set; }
        public List<Cart> Carts { get; set; }
        public List<UserOrder> UserOrders { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
