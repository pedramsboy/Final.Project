using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Patients.Contracts.Commands
{
    public class AddPatientCommand
    {
        public string NationalCode { get; set; }
        public string PatientDescription { get; set; }
        public string InsuranceName { get; set; }
        public string InsuranceDescription { get; set; }
        public string UserName { get; set; }
    }
}
