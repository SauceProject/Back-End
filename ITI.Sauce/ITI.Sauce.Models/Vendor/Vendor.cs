﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class Vendor
    {
        public List<string> Phones;

        public string ID { get; set; }
        public DateTime registerDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Users User { get; set; }
        public virtual List<Vendor_MemberShip>? Vendor_MemberShips { get; set; }
        public virtual List<Restaurant>? Restaurants { get; set; }
    

    }
}
