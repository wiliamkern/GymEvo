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

namespace GymEvo.Application.Instructors
{
    public class InstructorHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public InstructorHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<InstructorDto>> GetAll()
        {
            var resultReturn = await _uow.InstructorRepository.Find(x => x.IsActive)
                .AsNoTracking()
                //.Include(x => x.UnitMeasure)
                .ProjectTo<InstructorDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return new List<InstructorDto>(resultReturn);
        }

        public async Task<InstructorDto> Get(int Id)
        {
            var exercise = await _uow.InstructorRepository.Find(x => x.IsActive && x.InstructorId == Id)
                .ProjectTo<InstructorDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return exercise ?? new InstructorDto();
        }

        public async Task<bool> Insert(InstructorDto instructor)
        {
            instructor.IsActive = true;

            var result = await _uow.InstructorRepository.CreateAsync(_mapper.Map<Instructor>(instructor));

            await _uow.Save();

            return string.IsNullOrEmpty(result.InstructorId.ToString());
        }

        public async Task<bool> Update(InstructorDto instructorDto)
        {
            var instructor = await _uow.InstructorRepository
                                            .Find(x => x.InstructorId == instructorDto.InstructorId)
                                            .FirstOrDefaultAsync();

            if (instructor == null)
                return false;

            var result = _uow.InstructorRepository.Update(_mapper.Map<Instructor>(instructorDto));

            await _uow.Save();

            return string.IsNullOrEmpty(result.InstructorId.ToString());
        }

        public async Task<bool> Delete(int Id)
        {
            var instructor = await _uow.InstructorRepository
                                            .Find(x => x.InstructorId == Id)
                                            .FirstOrDefaultAsync();

            if (instructor == null)
                return false;

            var result = _uow.InstructorRepository.Delete(Id);

            await _uow.Save();

            return string.IsNullOrEmpty(result.Id.ToString());
        }
    }
}
