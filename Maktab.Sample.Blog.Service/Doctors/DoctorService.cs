﻿using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Abstraction.Service.Exceptions;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Service.Configurations;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Commands;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Doctors
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly InternalGrantsSettings _grants;
        private readonly InternalGrantsSettings _grantsSettings;


        public DoctorService(IDoctorRepository repository, IDepartmentRepository departmentRepository, InternalGrantsSettings grants, IOptions<InternalGrantsSettings> settings)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
            _grants = grants;
            _grantsSettings = settings.Value;
        }


        public async Task<GeneralResult> AddDoctorAsync(AddDoctorCommand command)
        {
           
            var department = await _departmentRepository.GetAsync(command.DepartmentId);
            

            if (department == null)
                throw new ItemNotFoundException(nameof(Department));

            var doctor = new Doctor(command.FirstName, command.LastName, command.MedicalSystemCode, command.LevelOfSpeciality, command.DoctorService ,department.Id);
            await _repository.AddAsync(doctor);
            return new GeneralResult
            {
                Id = department.Id
            };
        }

        public async Task DeleteDoctorByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("Id is not valid.");

            var doctor = await _repository.GetAsync(id);

            if (doctor == null)
                throw new ItemNotFoundException(nameof(Doctor));


            await _repository.HardDeleteAsync(id);
        }

        public async Task<List<DoctorArgs>> GetAllDoctorsAsync(Expression<Func<Doctor, bool>> predicate)
        {
            var doctors = await _repository.QueryAsync(predicate ?? (p => true), include: d => d.Include(x => x.Prescriptions));

            return doctors.Select(p => p.MapToDoctorArgs()).ToList();
        }

        public async Task<List<DoctorArgs>> GetAllDoctorsByDepartmentIdAsync(Guid departmentId)
        {
            var doctors = await _repository.QueryAsync(d => d.DepartmentId == departmentId, include: d => d.Include(x => x.Prescriptions));

            return doctors.Select(d => d.MapToDoctorArgs()).ToList();
        }

        public async Task<DoctorArgs> GetDoctorByIdAsync(Guid id)
        {
            var doctor = await _repository.GetAsync(id, include: d => d.Include(x => x.Prescriptions));


            if (doctor == null)
                throw new ItemNotFoundException(nameof(Doctor));

            return doctor.MapToDoctorArgs();
        }

        public async Task<GetDoctorsListResult> GetDoctorsListAsync(Guid departmentId, Paging paging)
        {
            var result = await _repository.GetDoctorsListAsync(d => d.DepartmentId == departmentId, paging, include: d => d.Include(x => x.Prescriptions));

            var items = result.items.Select(d => d.MapToDoctorArgs()).ToList();
            return new GetDoctorsListResult(items, result.totalRows, paging);
        }

        public async Task UpdateDoctorAsync(UpdateDoctorCommand command)
        {
            var doctor = await _repository.GetAsync(command.Id, false);
            

            if (doctor == null)
                throw new ItemNotFoundException(nameof(Doctor));

            

            doctor.SetDoctorInfo(command.FirstName, command.LastName, command.MedicalSystemCode, command.LevelOfSpeciality, command.DoctorService);

            await _repository.UpdateAsync(doctor);
        }
    }
}
