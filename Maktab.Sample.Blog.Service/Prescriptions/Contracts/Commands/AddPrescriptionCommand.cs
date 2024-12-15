using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Prescriptions.Contracts.Commands
{
    public class AddPrescriptionCommand
    {
        public string Appointment { get; set; }
        public string PrescriptionDescription { get; set; }
        public string UserName { get; set; }
        public Guid AuthortId { get; set; }
        public Guid DoctorId { get; set; }
    }
}
