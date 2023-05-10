using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Models
{
   
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("id")] 
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(32)]
        public string? Name { get; set; }


        [ForeignKey("Pizza")]
        [Column("pizzas_id")]
        [Required]
        public int PizzaId { get; set; }
        public Pizzas? Pizza { get; set; }
    }
}