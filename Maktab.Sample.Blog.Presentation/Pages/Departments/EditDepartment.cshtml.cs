using Maktab.Sample.Blog.Presentation.Pages.Infirmaries;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Departments;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Infirmaries;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Departments
{
    public class EditDepartmentModel : PageModel
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<EditDepartmentModel> _logger;

        public EditDepartmentModel(IDepartmentService departmentService, ILogger<EditDepartmentModel> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        [BindProperty]
        public UpdateDepartmentModel UpdateDepartmentModel { get; set; }

        public async Task OnGetAsync(Guid postId)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(postId);
            UpdateDepartmentModel = new UpdateDepartmentModel()
            {
                Id = department.Id,
                DepartmentName=department.DepartmentName,
                DepartmentService = department.DepartmentService,
            };
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid)
            {
                var command = UpdateDepartmentModel.Adapt<UpdateDepartmentCommand>();
                try
                {
                    await _departmentService.UpdateDepartmentAsync(command);
                    TempData["SuccessMessage"] = "Department updated successfully.";
                    return RedirectToPage("/Departments/Index");

                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Something went wrong while updating Department: {command.Id}");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            return Page();
        }
    }
}
