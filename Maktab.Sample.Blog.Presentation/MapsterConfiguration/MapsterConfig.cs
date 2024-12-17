using Maktab.Sample.Blog.Presentation.Models.Accounting;
using Maktab.Sample.Blog.Presentation.Pages.Models;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Commands;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Patients.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Commands;
using Maktab.Sample.Blog.Service.Users.Contracts.Commands;
using Mapster;

namespace Maktab.Sample.Blog.Presentation.MapsterConfiguration;

public static class MapsterConfig
{
    public static void RegisterMapping()
    {
        TypeAdapterConfig<LoginViewModel, LoginCommand>.NewConfig();
        
        TypeAdapterConfig<RegisterViewModel, RegisterCommand>.NewConfig();

        TypeAdapterConfig<UpdatePostModel, UpdatePostCommand>.NewConfig()
            .Map(dest => dest.Title, src => src.PostTitle);

        TypeAdapterConfig<UpdateInfirmaryModel, UpdateInfirmaryCommand>.NewConfig();

        TypeAdapterConfig<UpdateDepartmentModel, UpdateDepartmentCommand>.NewConfig();

        TypeAdapterConfig<UpdatePatientModel, UpdatePatientCommand>.NewConfig();

        TypeAdapterConfig<UpdateDoctorModel, UpdateDoctorCommand>.NewConfig();

        TypeAdapterConfig<UpdatePrescriptionModel, UpdatePrescriptionCommand>.NewConfig();
    }
}