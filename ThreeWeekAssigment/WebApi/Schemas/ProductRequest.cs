﻿namespace WebApi.Schemas
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}