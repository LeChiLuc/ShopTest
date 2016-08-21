using ShopTest.Common;
using ShopTest.Model.Models;
using ShopTest.Service;
using ShopTest.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopTest.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IPostService _postService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IPostService postService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._postService = postService;
        }
        [ChildActionOnly]
        public ActionResult _ProductCategory()
        {
            var model = _productCategoryService.GetAll();
            return PartialView(model);
        }
        public ActionResult Category(int id,int page = 1,string sort="")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize,sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            ViewBag.Category = _productCategoryService.GetById(id);
            var paginationSet = new PaginationSet<Product>()
            {
                Items = productModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            return View(paginationSet);
        }
        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.Search(keyword, page, pageSize, sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            ViewBag.Keyword = keyword;
            var paginationSet = new PaginationSet<Product>()
            {
                Items = productModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            return View(paginationSet);
        }
        public JsonResult GetListProductByName(string keyword)
        {
            var model = _productService.GetListProductByName(keyword);
            return Json(new
            {
                data = model
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int id)
        {
            var productModel = _productService.GetById(id);
            ViewBag.relatedProduct = _productService.GetReatedProduct(id,6);

            ViewBag.Tags = _productService.GetListTagByProductId(id);
            
            return View(productModel);
        }
        public ActionResult ListByTag(string tagId,int page=1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.GetListProductByTag(tagId, page, pageSize, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            ViewBag.Tag = _productService.GetTag(tagId);
            var paginationSet = new PaginationSet<Product>()
            {
                Items = productModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
            };
            return View(paginationSet);
        }
    }
}