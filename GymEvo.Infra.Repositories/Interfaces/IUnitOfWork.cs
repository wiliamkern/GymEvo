using GymEvo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Infra.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Instructor> InstructorRepository { get; }
        IRepository<Exercise> ExerciseRepository { get; }
        IRepository<Class> ClassRepository { get; }
        IRepository<ClassCustomer> ClassCustomerRepository { get; }
        IRepository<ClassExercise> ClassExerciseRepository { get; }

        Task Save();
    }
}
