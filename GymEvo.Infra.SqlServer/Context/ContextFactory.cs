using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Infra.SqlServer.Context
{
    public class ContextFactory
    {
        public ServerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServerContext>();
            optionsBuilder.UseSqlServer("");

            return new ServerContext(optionsBuilder.Options);
        }
    }
}
