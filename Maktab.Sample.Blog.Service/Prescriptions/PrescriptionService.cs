using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Abstraction.Service.Exceptions;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.prescription;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Configurations;
using Maktab.Sample.Blog.Service.Doctors;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Commands;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Prescriptions
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _repository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly UserManager<User> _userManager;
        private readonly InternalGrantsSettings _grants;
        private readonly InternalGrantsSettings _grantsSettings;

        public PrescriptionService(IPrescriptionRepository repository, IDoctorRepository doctorRepository, UserManager<User> userManager, InternalGrantsSettings grants, IOptions<InternalGrantsSettings> settings)
        {
            _repository = repository;
            _doctorRepository = doctorRepository;
            _userManager = userManager;
            _grants = grants;
            _grantsSettings = settings.Value;
        }
        public async Task<GeneralResult> AddPrescriptionAsync(AddPrescriptionCommand command)
        {
            var doctor = await _doctorRepository.GetAsync(command.DoctorId);
            var user = await _userManager.FindByNameAsync(command.UserName);
            ;

            if (doctor == null)
                throw new ItemNotFoundException(nameof(Doctor));

            if (user == null)
                throw new ItemNotFoundException(nameof(User));

            var prescription = new Prescription(command.Appointment, command.PrescriptionDescription, doctor.Id, user.Id);
            await _repository.AddAsync(prescription);
            return new GeneralResult
            {
                Id = prescription.Id
            };
        }

        public async Task DeletePrescriptionByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("Id is not valid.");

            var prescription = await _repository.GetAsync(id);

            if (prescription == null)
                throw new ItemNotFoundException(nameof(Prescription));


             await _repository.SoftDeleteAsync(id);
            //await _repository.HardDeleteAsync(id);
        }

        public async Task<List<PrescriptionArgs>> GetAllPrescriptionsAsync(Expression<Func<Prescription, bool>> predicate)
        {
            var prescriptions = await _repository.QueryAsync(predicate ?? (p => true), include: p => p.Include(x => x.Author));

            return prescriptions.Select(p => p.MapToPrescriptionArgs()).ToList();
        }

        public async Task<List<PrescriptionArgs>> GetAllPrescriptionsByAuthorIdAsync(Guid authortId)
        {
            var prescriptions = await _repository.QueryAsync(p => p.AuthorId == authortId, include: p => p.Include(x => x.Author));

            return prescriptions.Select(p => p.MapToPrescriptionArgs()).ToList();
        }

        public async Task<List<PrescriptionArgs>> GetAllPrescriptionsByDoctorIdAsync(Guid doctortId)
        {
            var prescriptions = await _repository.QueryAsync(p => p.DoctorId == doctortId, include: p => p.Include(x => x.Author));

            return prescriptions.Select(p => p.MapToPrescriptionArgs()).ToList();
        }

        public async Task<PrescriptionArgs> GetPrescriptionByIdAsync(Guid id)
        {
            var prescription = await _repository.GetAsync(id, include: p => p.Include(x => x.Author));


            if (prescription == null)
                throw new ItemNotFoundException(nameof(Prescription));

            return prescription.MapToPrescriptionArgs();
        }

        public async Task HardDeletePrescriptionByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("Id is not valid.");

            var prescription = await _repository.GetAsync(id);

            if (prescription == null)
                throw new ItemNotFoundException(nameof(Prescription));


            await _repository.HardDeleteAsync(id);
        }

        public async Task UpdatePrescriptionAsync(UpdatePrescriptionCommand command)
        {
            var prescription = await _repository.GetAsync(command.Id, false);


            if (prescription == null)
                throw new ItemNotFoundException(nameof(Prescription));



            prescription.SetPrescriptionInfo(command.Appointment, command.PrescriptionDescription);

            await _repository.UpdateAsync(prescription);
        }
    }
}
