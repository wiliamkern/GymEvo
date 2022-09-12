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
    public class ClassExerciseConfiguration : IEntityTypeConfiguration<ClassExercise>
    {
        public void Configure(EntityTypeBuilder<ClassExercise> builder)
        {
            Ignores(builder);
            Relationships(builder);
        }

        private static void Relationships(EntityTypeBuilder<ClassExercise> builder)
        {
            builder
                .HasKey(key => new { key.ExerciseId, key.ClassId });
        }

        private static void Ignores(EntityTypeBuilder<ClassExercise> builder)
        {
        }
    }
}
