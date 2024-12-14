using Maktab.Sample.Blog.Presentation.Pages.Infirmaries;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Infirmaries;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Patients;
using Maktab.Sample.Blog.Service.Patients.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Patients
{
    public class EditPatientModel : PageModel
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<EditPatientModel> _logger;

        public EditPatientModel(IPatientService patientService, ILogger<EditPatientModel> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [BindProperty]
        public UpdatePatientModel UpdatePatientModel { get; set; }
        public async Task OnGetAsync(Guid postId)
        {
            var patient = await _patientService.GetPatientByIdAsync(postId);
            UpdatePatientModel = new UpdatePatientModel()
            {
                Id = patient.Id,
                NationalCode = patient.NationalCode,
                PatientDescription = patient.PatientDescription,
                InsuranceName = patient.InsuranceName,
                IsuranceDescription = patient.PatientDescription,
                
            };
        }


        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid)
            {
                var command = UpdatePatientModel.Adapt<UpdatePatientCommand>();
                try
                {
                    await _patientService.UpdatePatientAsync(command, User.Identity?.Name ?? string.Empty);
                    TempData["SuccessMessage"] = "Information updated successfully.";
                    return RedirectToPage("/Patients/Index");

                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Something went wrong while updating Information: {command.Id}");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            return Page();
        }
    }
}
