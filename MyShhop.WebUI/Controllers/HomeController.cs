﻿using MyShhop.Core.Contracts;
using MyShhop.Core.Models;
using MyShhop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShhop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoriesContext)
        {
            context = productContext;
            productCategories = productCategoriesContext;
        }
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();
            if(Category == null)
            {
                products=context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel Model = new ProductListViewModel();
            Model.Product = products;
            Model.ProductCategories = categories;

            return View(Model);
        }

        public ActionResult Details(string Id){
            Product product = context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
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