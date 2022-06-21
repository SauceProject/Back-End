using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
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
