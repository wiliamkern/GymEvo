using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymEvo.Application.DTOs;
using GymEvo.Domain.Entity;
using GymEvo.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Application.Classes
{
    public class ClassHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ClassHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<ClassDto>> GetAll()
        {
            var resultReturn = await _uow.ClassRepository.Find(x => x.IsActive)
                .AsNoTracking()
                .Include(x => x.Instructor)
                .Include(x => x.Customers)
                .Include(x => x.Exercises)
                .ProjectTo<ClassDto>(_mapper.ConfigurationProvider)
                .OrderByDescending(x => x.ClassEndDate)
                .ToListAsync();

            return new List<ClassDto>(resultReturn);
        }

        public async Task<ClassDto> Get(int Id)
        {
            var classDto = await _uow.ClassRepository.Find(x => x.IsActive && x.ClassId == Id)
                .Include(x => x.Instructor)
                .Include(x => x.Customers)
                .Include(x => x.Exercises)
                .ProjectTo<ClassDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return classDto ?? new ClassDto();
        }

        public async Task<bool> Insert(ClassDto classDto)
        {
            classDto.IsActive = true;

            var result = await _uow.ClassRepository.CreateAsync(_mapper.Map<Class>(classDto));

            classDto.ClassId = result.ClassId; // seta o novo id da turma

            _ = UpsertCustomersAsync(classDto);
            _ = UpsertExercisesAsync(classDto);

            await _uow.Save();

            return string.IsNullOrEmpty(result.ClassId.ToString());
        }

        public async Task<bool> Update(ClassDto classDto)
        {
            var customer = await _uow.ClassRepository
                                            .Find(x => x.ClassId == classDto.ClassId)
                                            .FirstOrDefaultAsync();

            if (customer == null)
                return false;

            var result = _uow.ClassRepository.Update(_mapper.Map<Class>(classDto));

            _ = UpsertCustomersAsync(classDto);
            _ = UpsertExercisesAsync(classDto);

            await _uow.Save();

            return string.IsNullOrEmpty(result.ClassId.ToString());
        }

        // Remove todos os alunos e reinsere eles de acordo com retorno do front
        public async Task UpsertCustomersAsync(ClassDto classDto)
        {
            await _uow.ClassCustomerRepository.Delete(classDto.ClassId ?? 0);

            foreach (ClassCustomerDto row in classDto.Customers)
            {
                row.ClassId = classDto.ClassId;
                _ = _uow.ClassCustomerRepository.CreateAsync(_mapper.Map<ClassCustomer>(row));
            }
        }

        // Remove todos os exercicios e reinsere eles de acordo com retorno do front
        public async Task UpsertExercisesAsync(ClassDto classDto)
        {
            await _uow.ClassExerciseRepository.Delete(classDto.ClassId ?? 0);

            foreach (ClassExerciseDto row in classDto.Exercises)
            {
                row.ClassId = classDto.ClassId;
                _ = _uow.ClassExerciseRepository.CreateAsync(_mapper.Map<ClassExercise>(row));
            }
        }

        public async Task<bool> Delete(int Id)
        {
            var classData = await _uow.ClassRepository
                                            .Find(x => x.ClassId == Id)
                                            .FirstOrDefaultAsync();

            if (classData == null)
                return false;

            await _uow.ClassExerciseRepository.Delete(Id);
            await _uow.ClassCustomerRepository.Delete(Id);

            var result = _uow.ClassRepository.Delete(Id);

            await _uow.Save();

            return string.IsNullOrEmpty(result.Id.ToString());
        }
    }
}
