﻿namespace GymTEC_API.Entidades
{
    public class Shop
    {
        public string Branch_Name { get; set; } = string.Empty;
        public char Status { get; set; }

        public Product Shop_Product { get; set; } = new Product();
    }
}