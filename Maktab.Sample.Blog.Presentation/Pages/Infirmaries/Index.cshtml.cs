using System.Security.Claims;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Infirmaries;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Infirmaries
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public List<InfirmaryArgs> InfirmariesModel { get; set; }

        public Guid InfirmaryId { get; set; }
        private readonly IInfirmaryService _infirmaryService;

        public IndexModel(IInfirmaryService infirmaryService)
        {
            _infirmaryService = infirmaryService;
        }

        
        public async Task OnGetAsync()
        {
            InfirmariesModel = await _infirmaryService.GetAllInfirmariesAsync(p=> true);
            
        }

        public AddInfirmaryModel AddInfirmaryModel { get; set; }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            var infirmaryCommand = new AddInfirmaryCommand
            {
                InfirmaryName = AddInfirmaryModel.InfirmaryName,
                SupportedInsurance = AddInfirmaryModel.SupportedInsurance,
                State = AddInfirmaryModel.State,
                City = AddInfirmaryModel.City,
                Street = AddInfirmaryModel.Street,
                PhoneNumber = AddInfirmaryModel.PhoneNumber,
                IsAroundTheClock = AddInfirmaryModel.IsAroundTheClock,
                //UserName = User.Identity?.Name ?? string.Empty
            };

            var result = await _infirmaryService.AddInfirmaryAsync(infirmaryCommand);
            return RedirectToPage("/Infirmaries/Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            //var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());

            try
            {
                await _infirmaryService.DeleteInfirmaryByIdAsync(InfirmaryId/*, userId*/);
                TempData["SuccessMessage"] = "Infirmary deleted successfully.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage("/Infirmaries/Index");
        }
    }
}
