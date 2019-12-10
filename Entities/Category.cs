﻿using System;
using System.Collections.Generic;

namespace Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentCategoryID { get; set; }
        public List<Product> Products { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
