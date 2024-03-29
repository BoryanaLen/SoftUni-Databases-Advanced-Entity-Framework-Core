﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
    public class OrderImportDto
    {
        [Required]
        public string Customer { get; set; }

        [Required]
        public string Employee { get; set; }

        [Required]
        public string DateTime { get; set; }

        [Required]
        public string Type { get; set; } 

        public OrderItemImportDto[] Items { get; set; } 
    }
}
