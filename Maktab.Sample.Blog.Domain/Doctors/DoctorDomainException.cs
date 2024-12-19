using Maktab.Sample.Blog.Abstraction.Exceptions;
using Maktab.Sample.Blog.Domain.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Doctors
{
    public class DoctorDomainException : BaseException
    {
        public DoctorDomainException(string message, int sequence) : base(message)
        {
            Code = $"DoctorDomain_{sequence}";
        }
    }

    public class BaseEmptyArgumentException : DoctorDomainException
    {
        public BaseEmptyArgumentException(string argument, int sequence) : base($"{argument} can't be emtpy.", sequence)
        {
        }
    }

    public class EmptyFirstNameException : BaseEmptyArgumentException
    {
        public EmptyFirstNameException() : base("First Name", 1)
        {
        }
    }

    public class EmptyLastNameException : BaseEmptyArgumentException
    {
        public EmptyLastNameException() : base("Last Name", 2)
        {
        }
    }

    public class EmptyMedicalSystemCodeException : BaseEmptyArgumentException
    {
        public EmptyMedicalSystemCodeException() : base("Medical System Code", 3)
        {
        }
    }

    public class EmptyLevelOfSpecialityException : BaseEmptyArgumentException
    {
        public EmptyLevelOfSpecialityException() : base("Level Of Speciality", 4)
        {
        }
    }

    public class EmptyDoctorServiceException : BaseEmptyArgumentException
    {
        public EmptyDoctorServiceException() : base("Doctor Service", 5)
        {
        }
    }

    public class EmptyDepartmentIdException : BaseEmptyArgumentException
    {
        public EmptyDepartmentIdException() : base("Department Id", 6)
        {
        }
    }
}
