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

namespace GymEvo.Application.Exercises
{
    public class ExerciseHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ExerciseHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDto>> GetAll()
        {
            var resultReturn = await _uow.ExerciseRepository.Find(x => x.IsActive)
                .AsNoTracking()
                //.Include(x => x.UnitMeasure)
                .ProjectTo<ExerciseDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Description)
                .ToListAsync();

            return new List<ExerciseDto>(resultReturn);
        }

        public async Task<ExerciseDto> Get(int Id)
        {
            var exercise = await _uow.ExerciseRepository.Find(x => x.IsActive && x.ExerciseId == Id)
                .ProjectTo<ExerciseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return exercise ?? new ExerciseDto();
        }

        public async Task<bool> Insert(ExerciseDto exercise)
        {
            exercise.IsActive = true;

            var result = await _uow.ExerciseRepository.CreateAsync(_mapper.Map<Exercise>(exercise));

            await _uow.Save();

            return string.IsNullOrEmpty(result.ExerciseId.ToString());
        }

        public async Task<bool> Update(ExerciseDto exerciseDto)
        {
            var exercise = await _uow.ExerciseRepository
                                            .Find(x => x.ExerciseId == exerciseDto.ExerciseId)
                                            .FirstOrDefaultAsync();

            if (exercise == null)
                return false;

            var result = _uow.ExerciseRepository.Update(_mapper.Map<Exercise>(exerciseDto));

            await _uow.Save();

            return string.IsNullOrEmpty(result.ExerciseId.ToString());
        }

        public async Task<bool> Delete(int Id)
        {
            var exercise = await _uow.ExerciseRepository
                                            .Find(x => x.ExerciseId == Id)
                                            .FirstOrDefaultAsync();

            if (exercise == null)
                return false;

            var result = _uow.ExerciseRepository.Delete(Id);

            await _uow.Save();

            return string.IsNullOrEmpty(result.Id.ToString());
        }
    }
}
