using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_crud_mvc.Models
{
    [Table("pizzas")]
    public class Pizzas
    {
        [Key] 
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(32)]
        public string? Name { get; set; }
        [Required]
        [Column("description")]
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        [Column("image")]
        public string? Image { get; set; }
        [Required]
        [Column("price")]
        [Precision(9, 2)]
        public decimal Price { get; set; }

        [InverseProperty("Pizza")]
        public List<Category>? Categories { get; set; }
    }
}
