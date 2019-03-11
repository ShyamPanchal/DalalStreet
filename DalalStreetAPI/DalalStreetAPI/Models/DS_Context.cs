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
        public virtual DbSet<DS_CompanyCategory> DS_CompanyCategory { get; set; }
        public virtual DbSet<DS_NewCompanyNames> DS_NewCompanyNames { get; set; }
        public virtual DbSet<DS_EventTypes> DS_EventTypes { get; set; }
        public virtual DbSet<DS_NewsEvent> DS_NewsEvent { get; set; }


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

                entity.Property(e => e.CategoryId).IsRequired();
            });

            modelBuilder.Entity<DS_CompanyCategory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<DS_NewCompanyNames>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<DS_EventTypes>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.TypeString).IsRequired();

                entity.Property(e => e.Likelihood).IsRequired();

                entity.Property(e => e.EffectOnSelf).IsRequired();

                entity.Property(e => e.EffectOnOthers).IsRequired();
            });

            modelBuilder.Entity<DS_NewsEvent>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.OnCompanyId).IsRequired();

                entity.Property(e => e.EventTypeId).IsRequired();
            });

        }
    }
}
