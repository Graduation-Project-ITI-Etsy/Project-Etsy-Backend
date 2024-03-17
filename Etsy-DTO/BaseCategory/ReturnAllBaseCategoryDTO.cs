﻿using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.BaseCategory
{
    public class ReturnAllBaseCategoryDTO
    {
        public int Id { get; set; }
        public string? NameEN { get; set; }
        public string? NameAR { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
