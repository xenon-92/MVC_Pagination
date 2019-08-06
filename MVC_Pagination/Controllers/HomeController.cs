using MVC_Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Pagination.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            var dummyItems = Enumerable.Range(1, 152).Select(x=>"My custom item"+x);
            Pager pager = new Pager(dummyItems.Count(),page);
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            viewModel.pager = pager;            
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}