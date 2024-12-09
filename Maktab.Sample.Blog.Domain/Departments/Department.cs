using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Departments
{
    public class Department : BaseEntity
    {
        public Department(string departmentName, string departmentService, Guid authorId/*,Guid infirmaryId*/)
        {
            DepartmentName=departmentName;
            DepartmentService=departmentService;
            AuthorId = authorId;
            //InfirmaryId=infirmaryId;
            Validate();
        }

        /// <summary>
        /// Name of The Department(Clinic) 
        /// </summary>
        public string DepartmentName { get; set; } = string.Empty;
        /// <summary>
        ///  Different Sections (Deparments(Clinic)) of Infirmary With Different Services
        /// </summary>
        public string DepartmentService { get; set; } = string.Empty;
        

        /// <summary>
        /// Each Department Has a List of Doctors
        /// </summary>
        //public List<Doctor> Doctors { get; set; } = new();


        ///********************* navigation properties ********************/

        /// <summary>
        /// Id of The User Who Created This Infirmary
        /// </summary>
        public Guid AuthorId { get; private set; }
        /// <summary>
        /// Object Instance of The User Who Created This Infirmary
        /// </summary>
        public User Author { get; private set; }

        /// <summary>
        /// Infirmary id for navigation purposes
        /// </summary>
        //public Guid InfirmaryId { get; private set; }
        /// <summary>
        /// Infirmary object for navigation purposes
        /// </summary>
        //public Infirmary Infirmary { get; private set; }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(DepartmentName))
                throw new EmptyDepartmentNameException();

            if (string.IsNullOrWhiteSpace(DepartmentService))
                throw new EmptyDepartmentServiceException();

            if (AuthorId == null || AuthorId == Guid.Empty)
                throw new EmptyAuthorIdException();

            //if (InfirmaryId == null || InfirmaryId == Guid.Empty)
            //    throw new EmptyInfirmaryIdException();
        }

        public void SetDepartmentInfo(string departmentName, string departmentService)
        {
            if (!string.IsNullOrWhiteSpace(departmentName))
                DepartmentName = departmentName;

            if (!string.IsNullOrWhiteSpace(departmentService))
                DepartmentService = departmentService;

        }
    }
}
