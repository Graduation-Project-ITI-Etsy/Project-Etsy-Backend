﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BaseCategoryId { get; set; }
        public BaseCategory? BaseCategory { get; set; }
           public ICollection<Products>? Products { get; set; }

    }
}