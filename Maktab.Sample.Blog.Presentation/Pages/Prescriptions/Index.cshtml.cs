using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Doctors;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Commands;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Results;
using Maktab.Sample.Blog.Service.Prescriptions;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Commands;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Prescriptions
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public List<PrescriptionArgs> PrescriptionsModel { get; set; }

        public Guid PrescriptionId { get; set; }
        public Guid DoctorId { get; set; }
        //public Guid AuthorId { get; set; }

        private readonly IPrescriptionService _prescriptionService;

        public IndexModel(IPrescriptionService PrescriptionService)
        {
            _prescriptionService = PrescriptionService;
        }

        public async Task OnGetAsync(Guid doctorId)
        {
            DoctorId = doctorId;
            PrescriptionsModel = await _prescriptionService.GetAllPrescriptionsByDoctorIdAsync(DoctorId);
        }

        public AddPrescriptionModel AddPrescriptionModel { get; set; }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            var prescriptionCommand = new AddPrescriptionCommand
            {
                Appointment = AddPrescriptionModel.Appointment,
                PrescriptionDescription = AddPrescriptionModel.PrescriptionDescription,
                DoctorId = AddPrescriptionModel.DoctorId,
                UserName = User.Identity?.Name ?? string.Empty,
            };

            var result = await _prescriptionService.AddPrescriptionAsync(prescriptionCommand);
            return RedirectToPage("/Infirmaries/Index");
        }



        public async Task<IActionResult> OnPostDeleteAsync()
        {

            try
            {
                await _prescriptionService.DeletePrescriptionByIdAsync(PrescriptionId);
                TempData["SuccessMessage"] = "Appointment Has been Selected successfully.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage("/Infirmaries/Index");
        }



        public async Task<IActionResult> OnPostHardDeleteAsync()
        {

            try
            {
                await _prescriptionService.HardDeletePrescriptionByIdAsync(PrescriptionId);
                TempData["SuccessMessage"] = "Appointment Has been Deleted successfully.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage("/Infirmaries/Index");
        }
    }
}
