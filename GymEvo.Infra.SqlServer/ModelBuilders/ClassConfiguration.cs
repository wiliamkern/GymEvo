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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            Ignores(builder);
            Relationships(builder);
        }

        private static void Relationships(EntityTypeBuilder<Class> builder)
        {
            builder
                .HasKey(key => key.ClassId);
        }

        private static void Ignores(EntityTypeBuilder<Class> builder)
        {
        }
    }
}
