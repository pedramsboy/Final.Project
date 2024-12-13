using Maktab.Sample.Blog.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace Maktab.Sample.Blog.Presentation.Pages.Models
{
    public class UpdateInfirmaryModel
    {
        public Guid Id { get; set; }
        [Display(Name = "InfirmaryName", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(10, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string InfirmaryName { get; set; }

        [Display(Name = "SupportedInsurance", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(10, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [DataType(DataType.MultilineText)]
        public string SupportedInsurance { get; set; }

        [Display(Name = "State", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(3, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string State { get; set; }

        [Display(Name = "City", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(3, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string City { get; set; }

        [Display(Name = "Street", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(3, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string Street { get; set; }

        [Display(Name = "PhoneNumberProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [RegularExpression(@"^(0|\+98)\d{10}", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "IsAroundTheClock", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(10, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [DataType(DataType.MultilineText)]
        public string IsAroundTheClock { get; set; }
    }
}
