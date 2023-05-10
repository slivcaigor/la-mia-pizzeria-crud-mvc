using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_crud_mvc.Models;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (DataContext db = new())
            {
                List<Pizzas> pizzas = db.Pizzas.OrderBy(pizzas => pizzas.Id).Include(pizzas => pizzas.Categories).ToList<Pizzas>();

                return View("Index", pizzas);
            }
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            using (DataContext db = new())
            {
                Pizzas? pizzas = db.Pizzas.Where(pizzas => pizzas.Id == id).Include(pizzas => pizzas.Categories).FirstOrDefault();

                return View("Details", pizzas);
            }
        }
    }
}

