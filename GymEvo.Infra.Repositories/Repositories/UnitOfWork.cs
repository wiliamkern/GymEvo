using GymEvo.Domain.Entity;
using GymEvo.Infra.Repositories.Interfaces;
using GymEvo.Infra.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Infra.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbContext _context;
        private bool disposedValue;

        public UnitOfWork(IDbContext context)
        {
            _context = context;

            CustomerRepository = new Repository<Customer>(context);
            InstructorRepository = new Repository<Instructor>(context);
            ExerciseRepository = new Repository<Exercise>(context);
            ClassRepository = new Repository<Class>(context);
            ClassCustomerRepository = new Repository<ClassCustomer>(context);
            ClassExerciseRepository = new Repository<ClassExercise>(context);

        }

        public IRepository<Customer> CustomerRepository { get; }
        public IRepository<Instructor> InstructorRepository { get; }
        public IRepository<Exercise> ExerciseRepository { get; }
        public IRepository<Class> ClassRepository { get; }
        public IRepository<ClassCustomer> ClassCustomerRepository { get; }
        public IRepository<ClassExercise> ClassExerciseRepository { get; }


        public async Task Save()
            => await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
