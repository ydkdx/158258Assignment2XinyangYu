using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ass_2.Models
{
    public enum Category
    {
        Laptop,
        Computer,
        Tablet
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } // 这里添加了图片URL属性
        public Category Category { get; set; }
        // 其他属性...
    }
}