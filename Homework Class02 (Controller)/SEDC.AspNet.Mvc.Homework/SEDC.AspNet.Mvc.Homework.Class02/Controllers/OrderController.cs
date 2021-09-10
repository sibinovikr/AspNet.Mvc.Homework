using Microsoft.AspNetCore.Mvc;
using SEDC.AspNet.Mvc.Homework.Class02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Homework.Class02.Controllers
{
    [Route ("/pizza/order")]
    public class OrderController : Controller
    {
        [HttpGet("create-order")]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder(OrderModel request)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
