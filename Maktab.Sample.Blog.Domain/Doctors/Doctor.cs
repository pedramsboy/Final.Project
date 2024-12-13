using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Infirmaries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Doctors
{
    public class Doctor : BaseEntity
    {

        public Doctor(string firstName, string lastName, string medicalSystemCode, string levelOfSpeciality, string doctorService, Guid departmentId)
        {
            FirstName = firstName;
            LastName = lastName;
            MedicalSystemCode = medicalSystemCode;
            LevelOfSpeciality = levelOfSpeciality;
            DoctorService = doctorService;
            DepartmentId = departmentId;
            Validate();

        }

        /// <summary>
        /// First Name of The Doctor
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Last Name of The Doctor
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Medical System Code of Each Docotor
        /// </summary>
        public string MedicalSystemCode { get; set; } = string.Empty;

        /// <summary>
        /// The Doctor's Level of Speciality
        /// </summary>
        public string LevelOfSpeciality { get; set; } = string.Empty;


        /// <summary>
        /// Services That Each Dcotor Can Provides
        /// </summary>
        public string DoctorService { get; set; } = string.Empty;


        ///********************* Navigation Properties ********************/


        /// <summary>
        /// Department Id For Navigation Purposes
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Department Object For Navigation Purposes
        /// </summary>
        public Department Department { get; set; }


        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new EmptyFirstNameException();

            if (string.IsNullOrWhiteSpace(LastName))
                throw new EmptyLastNameException();

            if (string.IsNullOrWhiteSpace(MedicalSystemCode))
                throw new EmptyMedicalSystemCodeException();

            if (string.IsNullOrWhiteSpace(LevelOfSpeciality))
                throw new EmptyLevelOfSpecialityException();

            if (string.IsNullOrWhiteSpace(DoctorService))
                throw new EmptyDoctorServiceException();

            if (DepartmentId == null || DepartmentId == Guid.Empty)
                throw new EmptyDepartmentIdException();
        }

        public void SetDoctorInfo(string firstName, string lastName, string medicalSystemCode, string levelOfSpeciality, string doctorService)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                FirstName = firstName;

            if (!string.IsNullOrWhiteSpace(lastName))
                LastName = lastName;

            if (!string.IsNullOrWhiteSpace(medicalSystemCode))
                MedicalSystemCode = medicalSystemCode;

            if (!string.IsNullOrWhiteSpace(levelOfSpeciality))
                LevelOfSpeciality = levelOfSpeciality;

            if (!string.IsNullOrWhiteSpace(doctorService))
                DoctorService = doctorService;


        }
    }
}
