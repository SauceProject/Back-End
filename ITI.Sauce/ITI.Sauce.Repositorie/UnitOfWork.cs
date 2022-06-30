using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;

namespace ITI.Sauce.Repository
{
    public class UnitOfWork
    {
        private readonly DBContext context;
        public UnitOfWork(DBContext _Context)
        {
            context = _Context;
        }
        public void Save()
        {
            context.SaveChanges();
        } 
    }
}
