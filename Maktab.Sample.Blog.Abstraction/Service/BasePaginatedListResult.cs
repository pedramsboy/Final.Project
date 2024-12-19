﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Abstraction.Service
{
    public class BasePaginatedListResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRows { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public int GetTotalPages() => (int)Math.Ceiling((double)TotalRows / PageSize);
    }
}
