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
    public class ClassCustomerConfiguration : IEntityTypeConfiguration<ClassCustomer>
    {
        public void Configure(EntityTypeBuilder<ClassCustomer> builder)
        {
            Ignores(builder);
            Relationships(builder);
        }

        private static void Relationships(EntityTypeBuilder<ClassCustomer> builder)
        {
            builder
                .HasKey(key => new { key.CustomerId, key.ClassId });
        }

        private static void Ignores(EntityTypeBuilder<ClassCustomer> builder)
        {
        }
    }
}
