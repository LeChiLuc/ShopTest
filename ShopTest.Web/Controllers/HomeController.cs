﻿using ShopTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISlideService _slideService;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        public HomeController(IProductService productService, IProductCategoryService productCategoryService, ISlideService slideService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._slideService = slideService;
        }
        public ActionResult Index()
        {
            ViewBag.NewProduct = _productService.ListNewProduct(3);
            ViewBag.HotProduct = _productService.ListFeatureProduct(3);
            var model = _slideService.GetAll();
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult _Footer()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult _Header()
        {
            return PartialView();
        }
    }
}