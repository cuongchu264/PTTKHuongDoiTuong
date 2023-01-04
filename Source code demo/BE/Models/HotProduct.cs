﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models
{
    public class HotProduct
    {
        [Key]
        public int HotProductId { get; set; }
        public string HotProductName { get; set; }
        public int CategoryId { get; set; }
        public double HPPrice { get; set; }
        public string HPAvatar { get; set; }
        public string HPDescription { get; set; }
        public int HPInStocks { get; set; }
        public string Img1 { get; set; }
    }
}
