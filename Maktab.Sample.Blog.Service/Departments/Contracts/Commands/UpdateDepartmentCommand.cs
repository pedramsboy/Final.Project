using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Departments.Contracts.Commands
{
    public class UpdateDepartmentCommand
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentService { get; set; }
    }
}
