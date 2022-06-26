using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ITI.Sauce.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
<<<<<<< HEAD
using ITI.Sauce.Repository;
=======
>>>>>>> 783921fa5e0bed8b700af798c7f20caf4a815bea

namespace ITI.Sauce.Repositories
{
    public class GeneralRepository<T> where T : class
    {
        private readonly DBContext dbContext;
        private DbSet<T> Set;
<<<<<<< HEAD
        private readonly UnitOfWork unitOfWork;
        public GeneralRepository()
=======
        public GeneralRepository(DBContext _Context)
>>>>>>> 783921fa5e0bed8b700af798c7f20caf4a815bea
        {
            dbContext = _Context;
            Set = dbContext.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string orderBy = null, bool isAscending = false
                     , int pageIndex = 1, int pageSize = 20
             , params string[] includProps)
        {
            var query = Set.AsQueryable();
            foreach (string prop in includProps)
                query = query.Include(prop);
            if (filter != null)
                query = query.Where(filter);
            if (orderBy != null)
                query = query.OrderBy(orderBy, isAscending);
            int rowsCount = query.Count();
            if (rowsCount < pageSize)
                pageIndex = 1;
            if (pageIndex <= 0)
                pageIndex = 1;
            int excludedRowsCount = (pageIndex - 1) * pageSize;
            query = query.Skip(excludedRowsCount).Take(pageSize);
            return query;
        }

        public IQueryable<T> GetList()
        {
            return Set.AsQueryable();
        }
        public IQueryable<T> GetByID(int ID)
        {
            return Set.AsQueryable().Where(e => e.Equals(ID));
        }

<<<<<<< HEAD
        //public EntityEntry <T> Add (T entity)=>
        //    Set.Add(entity);

        //public EntityEntry<T> Update (T entity)=>
        //    Set.Update(entity);

        //public EntityEntry<T> Remove(T entity) =>
        //    Set.Remove(entity);
=======
        public EntityEntry<T> Add(T entity) =>
             Set.Add(entity);
        public EntityEntry<T> Update(T entity) =>
             Set.Update(entity);
        public EntityEntry<T> Remove(T entity) =>
            Set.Remove(entity);
>>>>>>> 783921fa5e0bed8b700af798c7f20caf4a815bea
    }
}
