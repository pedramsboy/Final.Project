﻿using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Departments
{
    public class DepartmentRepository : GenericRepository<Department, SqlServerDbContext>, IDepartmentRepository
    {
        public DepartmentRepository(SqlServerDbContext dbContext, ILogger<DepartmentRepository> logger) : base(dbContext, logger)
        {
        }

        public async Task<List<Department>> DepartmentsList(Guid infirmaryId)
        {
            return await QueryAsync(d => d.InfirmaryId == infirmaryId);
        }

        public async Task<List<Department>> SearchDepartmentsByTitle(string title)
        {
            return await QueryAsync(p => p.DepartmentName.Contains(title));
        }
    }
}
