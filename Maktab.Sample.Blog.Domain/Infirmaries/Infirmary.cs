using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Infirmaries
{
    public class Infirmary : BaseEntity
    {
        public Infirmary(string infirmaryName, string supportedInsurance, string state, string city, string street, string phoneNumber,bool isAroundTheClock, Guid authorId)
        {
            InfirmaryName = infirmaryName;
            SupportedInsurance = supportedInsurance;
            State = state;
            City = city;
            Street = street;
            PhoneNumber = phoneNumber;
            IsAroundTheClock = isAroundTheClock;
            AuthorId = authorId;
            Validate();
        }

        
        /// <summary>
        /// Name Of The Infirmary
        /// </summary>
        public string InfirmaryName { get; set; } = string.Empty;
        /// <summary>
        /// Classification of The Infirmary Types
        /// </summary>
        public InfirmaryClassification Classification { get; set; }
        /// <summary>
        /// Different Types of Infimary
        /// </summary>
        public InfirmaryType Type { get; set; }
        /// <summary>
        /// Each Supported Insurances In an Infirmary
        /// </summary>
        public string SupportedInsurance { get; set; } = string.Empty;
        /// <summary>
        /// The State of The Infirmary Where It's Located
        /// </summary>
        public string State { get; set; } = string.Empty;
        /// <summary>
        /// The City of The Infirmary Where It's Located
        /// </summary>
        public string City { get; set; } = string.Empty;
        /// <summary>
        /// The Street of The Infirmary Where It's Located
        /// </summary>
        public string Street { get; set; } = string.Empty;
        /// <summary>
        /// Phone Number of The Infirmary
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;
        
        /// <summary>
        /// Does Work Over Night or Not
        /// </summary>
        public Boolean IsAroundTheClock { get; set; }

        public enum InfirmaryClassification
        {
            Community,
            Private,
            All
        }

        public enum InfirmaryType
        {
            Hospital,
            Laboratory,
            ImagingCenter,
            Clinic
        }

        /// <summary>
        /// Id of The User Who Created This Infirmary
        /// </summary>
        public Guid AuthorId { get; private set; }
        /// <summary>
        /// Object Instance of The User Who Created This Infirmary
        /// </summary>
        public User Author { get; private set; }

        /// <summary>
        /// Each Infirmary Has a List of Departments
        /// </summary>
        //public List<Department> Departments { get; set; } = new ();
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(InfirmaryName))
                throw new EmptyInfirmaryNameException();

            if (string.IsNullOrWhiteSpace(SupportedInsurance))
                throw new EmptySupportedInsuranceException();

            if (string.IsNullOrWhiteSpace(State))
                throw new EmptyStateException();

            if (string.IsNullOrWhiteSpace(City))
                throw new EmptyCityException();

            if (string.IsNullOrWhiteSpace(Street))
                throw new EmptyStreetException();

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                throw new EmptyPhoneNumberException();

            if (AuthorId == null || AuthorId == Guid.Empty)
                throw new EmptyAuthorIdException();


        }

        public void SetInfirmaryInfo(string infirmaryName, string supportedInsurance, string state, string city, string street, string phoneNumber, bool isAroundTheClock)
        {
            if (!string.IsNullOrWhiteSpace(infirmaryName))
                InfirmaryName = infirmaryName;

            if (!string.IsNullOrWhiteSpace(supportedInsurance))
                SupportedInsurance = supportedInsurance;

            if (!string.IsNullOrWhiteSpace(state))
                State = state;

            if (!string.IsNullOrWhiteSpace(city))
                City = city;

            if (!string.IsNullOrWhiteSpace(street))
                Street = street;

            if (!string.IsNullOrWhiteSpace(phoneNumber))
                PhoneNumber = phoneNumber;

            IsAroundTheClock = isAroundTheClock;
        }
    }
}
