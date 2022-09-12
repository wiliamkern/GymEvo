using GymEvo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Infra.SqlServer.ModelBuilders
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            Ignores(builder);
            Relationships(builder);
        }

        private static void Relationships(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(key => key.InstructorId);
        }

        private static void Ignores(EntityTypeBuilder<Instructor> builder)
        {
        }
    }
}
