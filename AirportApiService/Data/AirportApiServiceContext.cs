using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLib;

namespace AirportApiService.Data
{
    public class AirportApiServiceContext : DbContext
    {
        public AirportApiServiceContext (DbContextOptions<AirportApiServiceContext> options)
            : base(options)
        {
        }

        public DbSet<ModelsLib.Airport> Airport { get; set; }
    }
}
