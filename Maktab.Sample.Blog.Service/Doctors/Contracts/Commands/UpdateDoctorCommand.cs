using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Doctors.Contracts.Commands
{
    public class UpdateDoctorCommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MedicalSystemCode { get; set; }

        public string LevelOfSpeciality { get; set; }

        public string DoctorService { get; set; }
    }
}
