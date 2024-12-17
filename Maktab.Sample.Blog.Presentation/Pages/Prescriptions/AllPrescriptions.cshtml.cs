using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Commands;
using Maktab.Sample.Blog.Service.Prescriptions;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Maktab.Sample.Blog.Presentation.Pages.Prescriptions
{
    [BindProperties]
    public class AllPrescriptionsModel : PageModel
    {
       public List<PrescriptionArgs> PrescriptionsModel { get; set; }

        public Guid PrescriptionId { get; set; }
        
        public Guid AuthorId { get; set; }

        private readonly IPrescriptionService _prescriptionService;

        public AllPrescriptionsModel(IPrescriptionService PrescriptionService)
        {
            _prescriptionService = PrescriptionService;
        }

        public async Task OnGetAsync()
        {

            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
            AuthorId = userId;
            PrescriptionsModel = await _prescriptionService.GetAllPrescriptionsByAuthorIdAsync(AuthorId);
        }

        

        public async Task<IActionResult> OnPostDeleteAsync()
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

            return RedirectToPage("/Prescriptions/AllPrescriptions");
        }

    }
}
