using AutoMapper;
using GymEvo.Application.DTOs;
using GymEvo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Domain.Mapper.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Instructor, InstructorDto>();
            CreateMap<Class, ClassDto>();
            CreateMap<Exercise, ExerciseDto>();
            CreateMap<ClassExercise, ClassExerciseDto>();
            CreateMap<ClassCustomer, ClassCustomerDto>();
        }
    }
}
