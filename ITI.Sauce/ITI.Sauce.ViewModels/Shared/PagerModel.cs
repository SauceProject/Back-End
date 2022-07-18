using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.ViewModels
{
    public class PagerModel
    {
        public PagerModel()
        { }
        //Read only Proeprties , I made Readonly by Making the Set method Private.
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int StartRecord { get; private set; }
        public int EndRecord { get; private set; }

        //public Propergties
        public string Action { get; set; } = "Search";
        public string SortExpression { get; set; }

        public PagerModel(int totalItems, int currentPage, int pageSize = 5)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;

            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            totalPages = totalPages;
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                    startPage = endPage - 9;
            }
            StartRecord = (CurrentPage - 1) * pageSize + 1;
            EndRecord = StartRecord - 1 + PageSize;

            if (EndRecord > TotalItems)
                EndRecord = TotalItems;
            if (TotalItems == 0)
            {
                StartPage = 0;
                StartRecord = 0;
                CurrentPage = 0;
                EndRecord = 0;
            }
            else
            {
                StartPage = startPage;
                EndPage = endPage;
            }
        }

    }
}
