using Maktab.Sample.Blog.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace Maktab.Sample.Blog.Presentation.Pages.Models
{
    public class AddDoctorModel
    {
        [Display(Name = "FirstNameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthStringValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string FirstName { get; set; }

        [Display(Name = "LastNameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [StringLength(30, ErrorMessageResourceName = "StringLengthValidationMessage", ErrorMessageResourceType = typeof(PresentationResources), MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "MedicalSystemCodeProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(10, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(11, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        [RegularExpression(@"^[0-9]+$", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MedicalSystemStringValidationMessage")]
        public string MedicalSystemCode { get; set; }

        [Display(Name = "LevelOfSpecialityProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string LevelOfSpeciality { get; set; }

        [Display(Name = "DoctorServiceProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [DataType(DataType.MultilineText)]
        public string DoctorService { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
