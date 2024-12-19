using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Patients;
using Maktab.Sample.Blog.Service.Patients.Contracts.Commands;
using Maktab.Sample.Blog.Service.Patients.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Maktab.Sample.Blog.Presentation.Pages.Patients
{
    [BindProperties]
    public class IndexModel : PageModel
    {

        public List<PatientArgs> PatientModel { get; set; }
        public Guid PostId { get; set; }
        private readonly IPatientService _patientService;

        public IndexModel(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public async Task OnGetAsync()
        {
            PatientModel = await _patientService.GetAllPatientsAsync(p => true);
        }

        public AddPatientModel AddPatientModel { get; set; }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            var patientCommand = new AddPatientCommand
            {
                NationalCode = AddPatientModel.NationalCode,
                PatientDescription = AddPatientModel.PatientDescription,
                InsuranceName = AddPatientModel.InsuranceName,
                InsuranceDescription = AddPatientModel.IsuranceDescription,
                UserName = User.Identity?.Name ?? string.Empty
            };

            var result = await _patientService.AddPatientAsync(patientCommand);
            return RedirectToPage("/Patients/Index");
        }


        
    }
}
