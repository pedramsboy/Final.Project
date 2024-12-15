using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Departments;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using Maktab.Sample.Blog.Service.Infirmaries;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Maktab.Sample.Blog.Presentation.Pages.Departments
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public List<DepartmentArgs> DepartmentsModel { get; set; }

        public Guid DepartmentId { get; set; }
        public Guid InfirmaryId { get; set; }


        private readonly IDepartmentService _departmentService;

        public IndexModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task OnGetAsync(Guid infirmaryId)
        {
            InfirmaryId = infirmaryId;
            DepartmentsModel = await _departmentService.GetAllDepartmentsByInfirmaryIdAsync(InfirmaryId);
        }

        public AddDepartmentModel AddDepartmentModel { get; set; }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            var departmentCommand = new AddDepartmentCommand
            {
                DepartmentName = AddDepartmentModel.DepartmentName,
                DepartmentService = AddDepartmentModel.DepartmentService,
                InfirmaryId=AddDepartmentModel.InfirmaryId,
                //UserName = User.Identity?.Name ?? string.Empty
            };

            var result = await _departmentService.AddDepartmentAsync(departmentCommand);
            return RedirectToPage("/Infirmaries/Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            //var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());

            try
            {
                await _departmentService.DeleteDepartmentByIdAsync(DepartmentId);
                TempData["SuccessMessage"] = "Department deleted successfully.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage("/Infirmaries/Index");
        }
    }
}
