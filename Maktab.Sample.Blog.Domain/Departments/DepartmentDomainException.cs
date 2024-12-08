using Maktab.Sample.Blog.Abstraction.Exceptions;
using Maktab.Sample.Blog.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Departments
{
    public class DepartmentDomainException : BaseException
    {
        public DepartmentDomainException(string message, int sequence) : base(message)
        {
            Code = $"DepartmentDomain_{sequence}";
        }
    }

    public class BaseEmptyArgumentException : DepartmentDomainException
    {
        public BaseEmptyArgumentException(string argument, int sequence) : base($"{argument} can't be emtpy.", sequence)
        {
        }
    }

    public class EmptyDepartmentNameException : BaseEmptyArgumentException
    {
        public EmptyDepartmentNameException() : base("Department Name", 1)
        {
        }
    }

    public class EmptyDepartmentServiceException : BaseEmptyArgumentException
    {
        public EmptyDepartmentServiceException() : base("Department Service", 2)
        {
        }
    }

    public class EmptyAuthorIdException : BaseEmptyArgumentException
    {
        public EmptyAuthorIdException() : base("Author id", 3)
        {
        }
    }

    public class EmptyInfirmaryIdException : BaseEmptyArgumentException
    {
        public EmptyInfirmaryIdException() : base("Infirmary id", 4)
        {
        }
    }
}
