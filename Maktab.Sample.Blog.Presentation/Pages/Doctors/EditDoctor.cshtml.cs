using Maktab.Sample.Blog.Presentation.Pages.Departments;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Departments;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Doctors;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Doctors
{
    public class EditDoctorModel : PageModel
    {

        private readonly IDoctorService _doctorService;
        private readonly ILogger<EditDoctorModel> _logger;

        public EditDoctorModel(IDoctorService doctorService, ILogger<EditDoctorModel> logger)
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        [BindProperty]
        public UpdateDoctorModel UpdateDoctorModel { get; set; }


        public async Task OnGetAsync(Guid postId)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(postId);
            UpdateDoctorModel = new UpdateDoctorModel()
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                MedicalSystemCode = doctor.MedicalSystemCode,
                LevelOfSpeciality = doctor.LevelOfSpeciality,
                DoctorService = doctor.DoctorService,
            };
        }



        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid)
            {
                var command = UpdateDoctorModel.Adapt<UpdateDoctorCommand>();
                try
                {
                    await _doctorService.UpdateDoctorAsync(command);
                    TempData["SuccessMessage"] = "Doctor updated successfully.";
                    return RedirectToPage("/Infirmaries/Index");

                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Something went wrong while updating Doctor: {command.Id}");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            return Page();
        }
    }
}
