using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Patients
{
    public class Patient : BaseEntity
    {
        public Patient(string nationalCode, string patientDescription,string insuranceName,string insuranceDescription, Guid authorId)
        {
            NationalCode = nationalCode;
            PatientDescription = patientDescription;
            InsuranceName = insuranceName;
            InsuranceDescription = insuranceDescription;
            AuthorId = authorId;
            Validate();
        }
        /// <summary>
        /// National Code of Eeach Patient
        /// </summary>
        public string NationalCode { get; set; } = string.Empty;

        /// <summary>
        /// Patient's Medical Descriptions
        /// </summary>
        public string PatientDescription { get; set; } = string.Empty;

        /// <summary>
        /// Name Of Patient's Insurance
        /// </summary>
        public string InsuranceName { get; set; } = string.Empty;

        /// <summary>
        /// Each Patient's Insurance Description 
        /// </summary>
        public string InsuranceDescription { get; set; } = string.Empty;


        ///********************* navigation properties ********************/
        /// <summary>
        /// Id of The User Who Created This Infirmary
        /// </summary>
        public Guid AuthorId { get; private set; }
        /// <summary>
        /// Object Instance of The User Who Created This Infirmary
        /// </summary> 
        public User Author { get; private set; }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(NationalCode))
                throw new EmptyNationalCodeException();

            if (string.IsNullOrWhiteSpace(PatientDescription))
                throw new EmptyPatientDescriptionException();

            if (string.IsNullOrWhiteSpace(InsuranceName))
                throw new EmptyInsuranceNameException();

            if (string.IsNullOrWhiteSpace(InsuranceDescription))
                throw new EmptyInsuranceDescriptionException();

            if (AuthorId == null || AuthorId == Guid.Empty)
                throw new EmptyAuthorIdException();
        }

        public void SetPatientInfo(string nationalCode, string patientDescription, string insuranceName, string insuranceDescription)
        {
            if (!string.IsNullOrWhiteSpace(nationalCode))
                NationalCode = nationalCode;

            if (!string.IsNullOrWhiteSpace(patientDescription))
                PatientDescription = patientDescription;

            if (!string.IsNullOrWhiteSpace(insuranceName))
                InsuranceName = insuranceName;

            if (!string.IsNullOrWhiteSpace(insuranceDescription))
                InsuranceDescription = insuranceDescription;
        }
    }
}
