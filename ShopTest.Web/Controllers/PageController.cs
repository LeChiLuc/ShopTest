using ShopTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTest.Web.Controllers
{
    public class PageController : Controller
    {
        IPageService _pageService;
        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }
        public ActionResult Index(string alias)
        {
            var page = _pageService.GetByAlias(alias);
            
            return View(page);
        }
    }
}