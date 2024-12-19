using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Departments;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using Maktab.Sample.Blog.Service.Infirmaries;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Maktab.Sample.Blog.Presentation.Pages.Departments
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        //public List<DepartmentArgs> DepartmentsModel { get; set; }

        public GetDepartmentsListResult DepartmentsModel { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid InfirmaryId { get; set; }


        private readonly IDepartmentService _departmentService;

        public IndexModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        
        public async Task OnGetAsync(Guid infirmaryId, [FromQuery] int pageSize = 3, [FromQuery] int pageNumber = 0)
        {
            InfirmaryId = infirmaryId;
            var paging = new Paging()
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
            };
            // DepartmentsModel = await _departmentService.GetAllDepartmentsByInfirmaryIdAsync(InfirmaryId);
            DepartmentsModel = await _departmentService.GetDepartmentsListAsync(InfirmaryId, paging);
        }

        public AddDepartmentModel AddDepartmentModel { get; set; }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            var departmentCommand = new AddDepartmentCommand
            {
                DepartmentName = AddDepartmentModel.DepartmentName,
                DepartmentService = AddDepartmentModel.DepartmentService,
                InfirmaryId=AddDepartmentModel.InfirmaryId,
                
            };

            var result = await _departmentService.AddDepartmentAsync(departmentCommand);
            return RedirectToPage("/Infirmaries/Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            

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
