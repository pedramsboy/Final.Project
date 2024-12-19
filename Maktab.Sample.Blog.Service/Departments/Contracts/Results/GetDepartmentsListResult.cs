﻿using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Departments.Contracts.Results
{
    public class GetDepartmentsListResult : BasePaginatedListResult<DepartmentArgs>
    {
        public GetDepartmentsListResult()
        {

        }
        public GetDepartmentsListResult(List<DepartmentArgs> items, int totalRows, int pageSize, int pageNumber)
        {
            Items = items;
            TotalRows = totalRows;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public GetDepartmentsListResult(List<DepartmentArgs> items, int totalRows, Paging paging)
        {
            Items = items;
            TotalRows = totalRows;
            PageSize = paging.PageSize;
            PageNumber = paging.PageNumber;
        }
    }
}
