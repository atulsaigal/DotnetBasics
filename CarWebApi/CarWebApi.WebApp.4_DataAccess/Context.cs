using CarWebApi.WebApp._4_DataAccess.Entity;
using CarWebApi.WebApp._4_DataAccess.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.WebApp._4_DataAccess
{
    public class Context:DbContext
    {
        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<CarEntity> CarDBset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>().ToTable("CarTable");
            modelBuilder.ApplyConfiguration(new EntityConfig());
        }

    }
}
