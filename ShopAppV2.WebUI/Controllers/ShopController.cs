﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopAppV2.Business.Abstract;
using ShopAppV2.Entities;
using ShopAppV2.WebUI.Models;

namespace ShopAppV2.WebUI.Controllers
{
    public class ShopController : Controller
        {
            private IProductService _productService;
            public ShopController(IProductService productService)
            {
                _productService = productService;
            }

            public IActionResult Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                Product product = _productService.GetProductDetails((int)id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(new ProductDetailsModel()
                {
                    Product = product,
                    Categories = product.ProductCategories.Select(i => i.Category).ToList()
                });
            }

            public IActionResult List(string category, int page = 1)
            {
                const int pageSize = 3;

            return View(new ProductListModel()
                {
                    Products = _productService.GetProductsByCategory(category, page, pageSize)
            });
            }
        }
}

