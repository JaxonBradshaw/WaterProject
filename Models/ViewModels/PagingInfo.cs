﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        //casting TotalNumItems to decimal, dividing, rounding up, and then making an int again.
        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage)); 

    }
}
