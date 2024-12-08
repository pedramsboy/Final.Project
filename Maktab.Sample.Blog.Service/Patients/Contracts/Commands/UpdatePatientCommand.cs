using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Patients.Contracts.Commands
{
    public class UpdatePatientCommand
    {
        public Guid Id { get; set; }
        public string NationalCode { get; set; }
        public string PatientDescription { get; set; }
        public string InsuranceName { get; set; }
        public string InsuranceDescription { get; set; }
    }
}
