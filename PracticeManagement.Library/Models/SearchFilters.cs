﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class SearchFilters
    {
        public bool showClosed { get; set; }
        public SearchFilters() 
        {
            showClosed = false;
        }

    }
}
