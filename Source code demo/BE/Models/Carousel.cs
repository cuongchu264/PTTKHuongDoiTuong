﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models
{
    public class Carousel
    {
        [Key]
        public int CarouselId { get; set; }
        public string Caption { get; set; }
        public string Text { get; set; }
        public string Img { get; set; }
        public string Link { get; set; }
    }
}
