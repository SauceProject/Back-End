﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using X.PagedList;


namespace ITI.Sauce.Repository
{
    public class CategoryRepository : GeneralRepository<Category>
    {
        public CategoryRepository(DBContext _Context) : base(_Context)
        {

        }
        public IPagedList<CategoryViewModel> Get(int ID = 0, string orderBy = null, bool isAscending = false,
            string NameEN = "", string NameAR = "", int pageIndex = 1, int pageSize = 20)

        {
            var filter = PredicateBuilder.New<Category>();
            var oldFiler = filter;
            if (ID > 0)
                filter = filter.Or(c => c.ID == ID);
            if (!string.IsNullOrEmpty(NameEN))
                filter = filter.Or(c => c.NameEN.Contains(NameEN));
            if (!string.IsNullOrEmpty(NameAR))
                filter = filter.Or(c => c.NameAR.Contains(NameAR));

            filter = filter.Or(c => c.IsDeleted == false);


            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize);
                

            var result =
                query.Select(i => new CategoryViewModel
                {
                    ID = i.ID,
                    NameEN = i.NameEN,
                    NameAR = i.NameAR,

                }).ToPagedList(pageIndex,pageSize);

            //PaginingViewModel<List<CategoryViewModel>>
            //    finalResult = new PaginingViewModel<List<CategoryViewModel>>()
            //    {
            //        PageIndex = pageIndex,
            //        PageSize = pageSize,
            //        Count = base.GetList().Count(),
            //        Data = result.ToList()
            //    };

            return result;


        }
        public IPagedList<CategoryViewModel> Search(int pageIndex = 1, int pageSize = 2)
                       =>
       GetList().Select(i => new CategoryViewModel
       {
           ID = i.ID,
           NameEN = i.NameEN,
           NameAR = i.NameAR,

       }).ToPagedList(pageIndex, pageSize);
        public CategoryViewModel Add (CategoryEditViewModel model)
        {
            Category category = model.ToModel();
            return base.Add(category).Entity.ToViewModel();
        }

        public CategoryViewModel Update(CategoryEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Category>();
            var old = filterd;

            filterd = filterd.Or(c => c.ID == model.ID);

            var Result = base.GetByID(filterd);
            Result.NameEN = model.NameEN;
            Result.NameAR = model.NameAR;
            

            return Result.ToViewModel();


        }
        public CategoryViewModel GetOne(int _ID = 0)
        {
            var filterd = PredicateBuilder.New<Category>();
            var old = filterd;
            if (_ID > 0)
                filterd = filterd.Or(c => c.ID == _ID);

            if (old == filterd)
                filterd = null;

            var query = base.GetByID(filterd);


            return query.ToViewModel();



        }

        public CategoryViewModel Remove(CategoryEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Category>();
            var old = filterd;

            filterd = filterd.Or(c => c.ID == model.ID);


            var Result = base.GetByID(filterd);

            Result.IsDeleted = true;

            return Result.ToViewModel();


        }
        public List<TextValueViewModel> GetCategoriesDropDown() =>
          GetList().Select(i => new TextValueViewModel
          {
              Value = i.ID,
              Text = i.NameEN
          }).ToList();
    }
}
