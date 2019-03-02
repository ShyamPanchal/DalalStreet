using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public partial class DS_Context : DbContext
    {
        public DS_Context() { }

        public DS_Context(DbContextOptions<DS_Context> options) : base(options) { }


        public virtual DbSet<DS_Company> DS_Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured){ }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DS_Company>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.stockValues).IsRequired();
            });
        }
    }
}
