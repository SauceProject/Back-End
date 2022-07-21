using ITI.Sauce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Repository
{
    public class Vendor_MembershipRepository : GeneralRepository<Vendor_MemberShip>
    {
        public Vendor_MembershipRepository(DBContext _Context) : base(_Context)
        {

        }
        public Vendor_MemberShip Add(string VendorID, int MembershipID )
        {
            Vendor_MemberShip VM = new Vendor_MemberShip() {
                Vendor_ID=VendorID, MemberShip_ID=MembershipID };
            return base.Add(VM).Entity;
 
        }
        public List<Vendor_MemberShip> Get(string VendorID)
        {
            
            return base.GetList().Where(i=>i.Vendor_ID==VendorID).ToList();

        }


    }
}
