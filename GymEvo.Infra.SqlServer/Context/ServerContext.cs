using GymEvo.Infra.SqlServer.Interfaces;
using GymEvo.Infra.SqlServer.ModelBuilders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Infra.SqlServer.Context
{
    public class ServerContext : IdentityDbContext, IDbContext, IDisposable
    {
        public ServerContext(DbContextOptions<ServerContext> options) : base(options) { }
        public ServerContext() : base() { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new InstructorConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new ClassConfiguration());
            builder.ApplyConfiguration(new ClassCustomerConfiguration());
            builder.ApplyConfiguration(new ClassExerciseConfiguration());
        }

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
