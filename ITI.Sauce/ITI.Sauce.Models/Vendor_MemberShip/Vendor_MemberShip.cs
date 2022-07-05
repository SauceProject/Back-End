using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Vendor_MemberShip
    {
        public int Vendor_ID { get; set; }
        public int MemberShip_ID { get; set; }
        public int NumberOfOrders { get; set; }
        public bool IsValid { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual MemberShip MemberShip { get; set; }
    }
}
