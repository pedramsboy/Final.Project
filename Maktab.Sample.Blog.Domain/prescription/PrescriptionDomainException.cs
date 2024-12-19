using Maktab.Sample.Blog.Abstraction.Exceptions;
using Maktab.Sample.Blog.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.prescription
{
    public class PrescriptionDomainException : BaseException
    {
        public PrescriptionDomainException(string message, int sequence) : base(message)
        {
            Code = $"PrescriptionDomain_{sequence}";
        }
    }


    public class BaseEmptyArgumentException : PrescriptionDomainException
    {
        public BaseEmptyArgumentException(string argument, int sequence) : base($"{argument} can't be emtpy.", sequence)
        {
        }
    }


    public class EmptyAppointmentException : BaseEmptyArgumentException
    {
        public EmptyAppointmentException() : base("Appointment ", 1)
        {
        }
    }


    public class EmptyDoctorIdException : BaseEmptyArgumentException
    {
        public EmptyDoctorIdException() : base("Doctor id", 2)
        {
        }
    }
    public class EmptyAuthorIdException : BaseEmptyArgumentException
    {
        public EmptyAuthorIdException() : base("Author id", 3)
        {
        }
    }
}
