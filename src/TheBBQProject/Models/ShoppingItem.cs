using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBBQProject.Models
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int ReviewCount { get; set; }

    }
}
