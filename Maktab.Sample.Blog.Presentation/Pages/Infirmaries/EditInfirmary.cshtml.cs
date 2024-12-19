using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Presentation.Pages.Posts;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Infirmaries
{
    public class EditInfirmaryModel : PageModel
    {
        private readonly IInfirmaryService _infirmaryService;
        private readonly ILogger<EditInfirmaryModel> _logger;

        public EditInfirmaryModel(IInfirmaryService infirmaryService, ILogger<EditInfirmaryModel> logger)
        {
            _infirmaryService = infirmaryService;
            _logger = logger;
        }

        [BindProperty]
        public UpdateInfirmaryModel UpdateInfirmaryModel { get; set; }
        public async Task OnGetAsync(Guid postId)
        {
            var infirmary = await _infirmaryService.GetInfirmaryByIdAsync(postId);
            UpdateInfirmaryModel = new UpdateInfirmaryModel()
            {
                Id = infirmary.Id,
                InfirmaryName = infirmary.InfirmaryName,
                SupportedInsurance = infirmary.SupportedInsurance,
                State = infirmary.State,
                City = infirmary.City,
                Street = infirmary.Street,
                PhoneNumber =infirmary.PhoneNumber,
                IsAroundTheClock =infirmary.IsAroundTheClock,
            };
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid)
            {
                var command = UpdateInfirmaryModel.Adapt<UpdateInfirmaryCommand>();
                try
                {
                    await _infirmaryService.UpdateInfirmaryAsync(command);
                    TempData["SuccessMessage"] = "Infirmary updated successfully.";
                    return RedirectToPage("/Infirmaries/Index");

                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Something went wrong while updating Infirmary: {command.Id}");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            return Page();
        }
    }
}
