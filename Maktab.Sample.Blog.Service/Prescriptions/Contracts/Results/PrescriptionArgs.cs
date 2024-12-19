using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.prescription;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Prescriptions.Contracts.Results
{
    public class PrescriptionArgs : GeneralResult
    {
        public string Appointment { get; set; }
        public string PrescriptionDescription { get; set; }
        public UserArgs? Author { get; set; }
        public Guid DoctortId { get; set; }
      

    }


    public static class PrescriptionArgsMapper
    {
        public static PrescriptionArgs MapToPrescriptionArgs(this Prescription prescription)
        {
            return new PrescriptionArgs
            {
                Id =prescription.Id,
                Appointment= prescription.Appointment,
                PrescriptionDescription = prescription.PrescriptionDescription,
                Author = prescription.Author?.MapToUserArgs(),
                DoctortId=prescription.DoctorId,
               
            };
        }
    }
}
