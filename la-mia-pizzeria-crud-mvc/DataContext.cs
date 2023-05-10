using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_mvc
{
    public class DataContext : DbContext
    {
        public DbSet<Pizzas> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=pizzadex;Integrated Security=True;TrustServerCertificate=True");

    }
}
