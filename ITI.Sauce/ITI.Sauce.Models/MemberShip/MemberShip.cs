using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class MemberShip
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int OrderNum { get; set; }
        public float Price { get; set; }
        public List<Vendor_MemberShip> Vendor_MemberShips { get; set; }
    }
}
