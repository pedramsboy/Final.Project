using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Abstraction.Service.Exceptions;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Configurations;
using Maktab.Sample.Blog.Service.Patients.Contracts.Commands;
using Maktab.Sample.Blog.Service.Patients.Contracts.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly InternalGrantsSettings _grants;
        private readonly InternalGrantsSettings _grantsSettings;

        public PatientService(IPatientRepository repository, UserManager<User> userManager, InternalGrantsSettings grants, IOptions<InternalGrantsSettings> settings)
        {
            _repository = repository;
            _userManager = userManager;
            _grants = grants;
            _grantsSettings = settings.Value;
        }
        public async Task<GeneralResult> AddPatientAsync(AddPatientCommand command)
        {
            var user = await _userManager.FindByNameAsync(command.UserName);
            if (user == null)
                throw new ItemNotFoundException(nameof(User));

            var patient = new Patient(command.NationalCode, command.PatientDescription, command.InsuranceName, command.InsuranceDescription, user.Id);
            await _repository.AddAsync(patient);
            return new GeneralResult
            {
                Id = patient.Id
            };
        }

        public async Task DeletePatientByIdAsync(Guid id, Guid userId)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("Id is not valid.");

            var patient = await _repository.GetAsync(id);

            if (patient == null)
                throw new ItemNotFoundException(nameof(Patient));

            if (patient.AuthorId != userId)
                throw new PermissionDeniedException();

            await _repository.HardDeleteAsync(id);
        }

        //public Task<List<PatientArgs>> GetAllPatientsAsync(Expression<Func<Patient, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<PatientArgs> GetPatientByIdAsync(Guid id)
        {
            var patient = await _repository.GetAsync(id,
            include: p => p.Include(x => x.Author));


            if (patient == null)
                throw new ItemNotFoundException(nameof(Patient));

            return patient.MapToPatientArgs();
        }

        public async Task UpdatePatientAsync(UpdatePatientCommand command, string userName)
        {
            var patient = await _repository.GetAsync(command.Id, false);
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new ItemNotFoundException(nameof(User));

            if (patient == null)
                throw new ItemNotFoundException(nameof(Patient));

            if (patient.AuthorId != user.Id)
                throw new PermissionDeniedException();

            patient.SetPatientInfo(command.NationalCode, command.PatientDescription, command.InsuranceName, command.InsuranceDescription);

            await _repository.UpdateAsync(patient);
        }
    }
}
