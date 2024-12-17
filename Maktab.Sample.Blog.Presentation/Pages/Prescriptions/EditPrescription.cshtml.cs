using Maktab.Sample.Blog.Presentation.Pages.Doctors;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Doctors;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Commands;
using Maktab.Sample.Blog.Service.Prescriptions;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Prescriptions
{
    public class EditPrescriptionModel : PageModel
    {

        private readonly IPrescriptionService _prescriptionService;
        private readonly ILogger<EditPrescriptionModel> _logger;

        public EditPrescriptionModel(IPrescriptionService prescriptionService, ILogger<EditPrescriptionModel> logger)
        {
            _prescriptionService = prescriptionService;
            _logger = logger;
        }

        [BindProperty]
        public UpdatePrescriptionModel UpdatePrescriptionModel { get; set; }

        public async Task OnGetAsync(Guid postId)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(postId);
            UpdatePrescriptionModel = new UpdatePrescriptionModel()
            {
                Id = prescription.Id,
                Appointment = prescription.Appointment,
                 PrescriptionDescription= prescription.PrescriptionDescription,
                
            };
        }


        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid)
            {
                var command = UpdatePrescriptionModel.Adapt<UpdatePrescriptionCommand>();
                try
                {
                    await _prescriptionService.UpdatePrescriptionAsync(command);
                    TempData["SuccessMessage"] = "Prescription updated successfully.";
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
