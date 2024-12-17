using Maktab.Sample.Blog.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace Maktab.Sample.Blog.Presentation.Pages.Models
{
    public class UpdatePrescriptionModel
    {
        public Guid Id { get; set; }
        [Display(Name = "AppointmentProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(1, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string Appointment { get; set; }

        [Display(Name = "PrescriptionDescriptionProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [DataType(DataType.MultilineText)]
        public string PrescriptionDescription { get; set; }
    }
}
