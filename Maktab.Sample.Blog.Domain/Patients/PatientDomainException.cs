using Maktab.Sample.Blog.Abstraction.Exceptions;
using Maktab.Sample.Blog.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Patients
{
    public class PatientDomainException : BaseException
    {
        public PatientDomainException(string message, int sequence) : base(message)
        {
            Code = $"PatientDomain_{sequence}";
        }
    }

    public class BaseEmptyArgumentException : PatientDomainException
    {
        public BaseEmptyArgumentException(string argument, int sequence) : base($"{argument} can't be emtpy.", sequence)
        {
        }
    }

    public class EmptyNationalCodeException : BaseEmptyArgumentException
    {
        public EmptyNationalCodeException() : base("National Code", 1)
        {
        }
    }

    public class EmptyPatientDescriptionException : BaseEmptyArgumentException
    {
        public EmptyPatientDescriptionException() : base("Patient Description", 2)
        {
        }
    }

    public class EmptyInsuranceNameException : BaseEmptyArgumentException
    {
        public EmptyInsuranceNameException() : base("Insurance Name", 3)
        {
        }
    }

    public class EmptyInsuranceDescriptionException : BaseEmptyArgumentException
    {
        public EmptyInsuranceDescriptionException() : base("Insurance Description", 4)
        {
        }
    }

    public class EmptyAuthorIdException : BaseEmptyArgumentException
    {
        public EmptyAuthorIdException() : base("Author id", 5)
        {
        }
    }
}
