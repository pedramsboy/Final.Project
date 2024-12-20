﻿using Maktab.Sample.Blog.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace Maktab.Sample.Blog.Presentation.Pages.Models
{
    public class AddDepartmentModel
    {
        [Display(Name = "DepartmentNameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string DepartmentName { get; set; }

        [Display(Name = "DepartmentServiceProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
        [DataType(DataType.MultilineText)]
        public string DepartmentService { get; set; }
        public Guid InfirmaryId { get; set; }
    }
}
