using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.prescription;
using Maktab.Sample.Blog.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.UsersPrescriptions
{
    public class UsersPrescriptions : BaseEntity
    {
        public UsersPrescriptions(Guid prescriptionId)
        {

        }


        ///********************* navigation properties ********************/
        /// <summary>
        /// Id of The Prescription 
        /// </summary>
        public Guid PrescriptionId { get; private set; }
        /// <summary>
        /// Object Instance of The Prscription
        /// </summary> 
        public Prescription Prescription { get; private set; }

        /// <summary>
        /// Id of The Prescription 
        /// </summary>
        public Guid AuthorId { get; private set; }
        /// <summary>
        /// Object Instance of The Prscription
        /// </summary> 
        public User Author { get; private set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
