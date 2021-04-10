using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoBanda.Models;

namespace TrabalhoBanda.Data
{
    public class IESContext : DbContext
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {

        }

        public DbSet<Banda> Bandas { get; set; }

        public DbSet<Musico> Musicos { get; set; }
    }
}
