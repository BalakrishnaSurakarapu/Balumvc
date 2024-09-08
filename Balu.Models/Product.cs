using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balu.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Discription { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [DisplayName("List Price")]
        [Range(1, 1000)]
        [Required]
        public double ListPrice { get; set; }
        [DisplayName("Price")]
        [Range(1, 1000)]
        [Required]
        public double Price { get; set; }
        [DisplayName("Price 50")]
        [Range(1, 1000)]
        [Required]
        public double Price50 { get; set; }
        [DisplayName("Price 100")]
        [Range(1, 1000)]
        [Required]
        public double Price100 { get; set; }
    }
}
