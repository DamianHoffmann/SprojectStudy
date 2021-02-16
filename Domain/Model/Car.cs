using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
   public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Engine { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public double Price { get; set; }
    }
}
