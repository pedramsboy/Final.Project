using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Prescriptions.Contracts.Commands
{
    public class UpdatePrescriptionCommand
    {
        public Guid Id { get; set; }
        public string Appointment { get; set; }
        public string PrescriptionDescription { get; set; }
    }
}
