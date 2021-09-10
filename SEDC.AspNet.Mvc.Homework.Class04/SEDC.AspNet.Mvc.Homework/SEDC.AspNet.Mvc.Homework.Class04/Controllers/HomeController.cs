using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SEDC.AspNet.Mvc.Homework.Class04.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Homework.Class04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {

            var model = context.Products.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Category = model.Category

                };
                context.Products.Add(newProduct);
                context.SaveChanges();
                return RedirectToAction("index", new { id = newProduct.Id });
            }
            return View();
        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                product = context.Products.Find(id ?? 1)
            };
            return View(homeDetailsViewModel);
        }

        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var file = await context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
            context.Products.Remove(file);
            context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
