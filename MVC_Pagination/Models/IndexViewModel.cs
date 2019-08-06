using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Pagination.Models
{
    public class IndexViewModel
    {
        public IEnumerable<string> Items { get; set; }
        public Pager pager { get; set; }
    }

    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentpage = page != null ? (int)page : 1;
            var startpage = currentpage - 5;
            var endpage = currentpage + 4;
            if (startpage <= 0)
            {
                endpage -= (startpage - 1);
                startpage = 1;
            }
            if (endpage > totalPages)
            {
                endpage = totalPages;
                if (endpage > 10)
                {
                    startpage = endpage - 9;
                }
            }
            TotalPages = totalPages;
            CurrentPage = currentpage;
            PageSize = pageSize;
            TotalItems = totalItems;
            StartPage = startpage;
            EndPage = endpage;
        }
    }
}