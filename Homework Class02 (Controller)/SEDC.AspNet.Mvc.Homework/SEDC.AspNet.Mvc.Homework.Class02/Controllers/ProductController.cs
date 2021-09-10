using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Homework.Class02.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProductById(int id)
        {
            return Json(new
            {
                Id = id,
                Name = "Product"
            });
        }

        public IActionResult GetProductByName(string name)
        {
            return Json(new
            {
                Id = 1,
                ProductName = name
            });
        }
    }
}
