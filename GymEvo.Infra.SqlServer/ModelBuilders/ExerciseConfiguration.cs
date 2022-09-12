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
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            Ignores(builder);
            Relationships(builder);
        }

        private static void Relationships(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasKey(key => key.ExerciseId);
        }

        private static void Ignores(EntityTypeBuilder<Exercise> builder)
        {
        }
    }
}
