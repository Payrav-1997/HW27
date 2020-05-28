using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW27.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Memory { get; set; }
        public decimal Prise { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
