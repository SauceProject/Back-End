using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.ViewModels.Vendor
{
    public class VendorViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public DateTime registerDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Vendor_MemberShip> Vendor_MemberShips { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}
