using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Patients
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<List<Patient>> SearchPatientsByTitle(string title);
    }
}
