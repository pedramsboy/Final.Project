using Maktab.Sample.Blog.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Doctors
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
    }
}
