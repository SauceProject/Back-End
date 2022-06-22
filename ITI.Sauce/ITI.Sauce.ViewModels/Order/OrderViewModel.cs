using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public class OrderViewModel
    {

        public int ID { get; set; }
      
        public string NameEN { get; set; }
        public string NameAR { get; set; }
        public string registerDate { get; set; }
        public int IsDeleted { get; set; }
    }
}
