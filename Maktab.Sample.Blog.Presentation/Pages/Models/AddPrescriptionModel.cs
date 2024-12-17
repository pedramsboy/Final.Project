using Maktab.Sample.Blog.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace Maktab.Sample.Blog.Presentation.Pages.Models
{
    public class AddPrescriptionModel
    {
        [Display(Name = "AppointmentProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(1, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string Appointment { get; set; }
        public string PrescriptionDescription { get; set; }
        public Guid DoctorId { get; set; }
        //public Guid AuthortId { get; set; }
    }
}
