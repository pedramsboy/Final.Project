using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Departments;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using Maktab.Sample.Blog.Service.Doctors;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Commands;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Maktab.Sample.Blog.Presentation.Pages.Doctors
{
    [BindProperties]
    public class IndexModel : PageModel
    {

        //public List<DoctorArgs> DoctorsModel { get; set; }

        public GetDoctorsListResult DoctorsModel { get; set; }
        public Guid DoctorId { get; set; }
        public Guid DepartmentId { get; set; }

        private readonly IDoctorService _doctorService;

        public IndexModel(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task OnGetAsync(Guid departmentId, [FromQuery] int pageSize = 3, [FromQuery] int pageNumber = 0)
        {
            DepartmentId = departmentId;

            var paging = new Paging()
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
            };

            //DoctorsModel = await _doctorService.GetAllDoctorsByDepartmentIdAsync(DepartmentId);
            DoctorsModel = await _doctorService.GetDoctorsListAsync(DepartmentId, paging);
        }


        public AddDoctorModel AddDoctorModel { get; set; }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            var doctorCommand = new AddDoctorCommand
            {
                FirstName = AddDoctorModel.FirstName,
                LastName = AddDoctorModel.LastName,
                MedicalSystemCode = AddDoctorModel.MedicalSystemCode,
                LevelOfSpeciality= AddDoctorModel.LevelOfSpeciality,
                DoctorService= AddDoctorModel.DoctorService,
                DepartmentId= AddDoctorModel.DepartmentId,
            };

            var result = await _doctorService.AddDoctorAsync(doctorCommand);
            return RedirectToPage("/Infirmaries/Index");
        }


        public async Task<IActionResult> OnPostDeleteAsync()
        {
           
            try
            {
                await _doctorService.DeleteDoctorByIdAsync(DoctorId);
                TempData["SuccessMessage"] = "Doctor deleted successfully.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage("/Infirmaries/Index");
        }
    }
}
