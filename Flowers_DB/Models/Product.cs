﻿namespace Flowers_DB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public byte Discount { get; set; }
        public Category Category { get; set; } 
    }
}
