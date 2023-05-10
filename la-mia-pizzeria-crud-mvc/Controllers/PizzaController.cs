using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.Extensions.Logging;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (DataContext db = new())
            {
                List<Pizzas> pizzas = db.Pizzas.OrderBy(pizzas => pizzas.Id).Include(pizzas => pizzas.Category).ToList<Pizzas>();

                return View("Index", pizzas);
            }
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            using (DataContext db = new())
            {
                Pizzas? pizzas = db.Pizzas.Where(pizzas => pizzas.Id == id).Include(pizzas => pizzas.Category).FirstOrDefault();

                return View("Details", pizzas);
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            using DataContext db = new();
            List<Category> categories = db.Categories.ToList();
            PizzaFormModel model = new()
            {
                Pizzas = new Pizzas(),
                Categories = categories
            };

            return View("Create", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaFormModel data)
        {
            if (!ModelState.IsValid)
            {
                using DataContext db = new();
                List<Category> categories = db.Categories.ToList();
                data.Categories = categories;
                return View(data);
            }

            using (DataContext db = new())
            {
                Pizzas pizza = new()
                {
                    Name = data?.Pizzas?.Name,
                    Description = data?.Pizzas?.Description,
                    Price = data?.Pizzas?.Price ?? 0,
                    Image = data?.Pizzas?.Image,
                };

                if (data.Pizzas.CategoryId != null)
                {
                    pizza.CategoryId = data.Pizzas.CategoryId;
                }

                db.Pizzas.Add(pizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}

