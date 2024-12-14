using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.prescription
{
    public class Prescription : BaseEntity
    {

        public Prescription(string appointment, string prescriptionDescription, Guid doctorId, Guid authorId)
        {
            Appointment = appointment;
            PrescriptionDescription = prescriptionDescription;
            DoctorId = doctorId;
            AuthorId = authorId;
            Validate();
        }

        /// <summary>
        /// Each Appointment of The Doctor
        /// </summary>
        public string Appointment { get; set; } = string.Empty;

        /// <summary>
        ///Each Prescription Description
        /// </summary>
        public string PrescriptionDescription { get; set; } = string.Empty;

        ///********************* navigation properties ********************/
        /// <summary>
        /// Id of The Doctor Who Can Visits Patients
        /// </summary>
        public Guid DoctorId { get; private set; }
        /// <summary>
        /// Object Instance of The Doctor Who Visits Patients
        /// </summary> 
        public Doctor Doctor { get; private set; }

        /// <summary>
        /// Id of The User 
        /// </summary>
        public Guid AuthorId { get; private set; }
        /// <summary>
        /// Object Instance of The User 
        /// </summary> 
        public User Author { get; private set; }


        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Appointment))
                throw new EmptyAppointmentException();

            if (string.IsNullOrWhiteSpace(PrescriptionDescription))
                throw new EmptyPrescriptionDescriptionException();

            if (DoctorId == null || DoctorId == Guid.Empty)
                throw new EmptyDoctorIdException();


            if (AuthorId == null || AuthorId == Guid.Empty)
                throw new EmptyAuthorIdException();
        }

        public void SetPrescriptionInfo(string appointment, string prescriptionDescription)
        {
            if (!string.IsNullOrWhiteSpace(appointment))
                Appointment = appointment;

            if (!string.IsNullOrWhiteSpace(prescriptionDescription))
                PrescriptionDescription = prescriptionDescription;

        }
    }
}
