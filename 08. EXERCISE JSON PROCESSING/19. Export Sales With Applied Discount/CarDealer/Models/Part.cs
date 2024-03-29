﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealer.Models
{
    public class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }


        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }


        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<PartCar> PartCars { get; set; }
    }
}
