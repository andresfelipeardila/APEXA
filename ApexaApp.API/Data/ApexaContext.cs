using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApexaApp.API.Models;
using Microsoft.EntityFrameworkCore;
using static ApexaApp.API.Helpers.Enums;

namespace ApexaApp.API.Data
{
    public class ApexaContext : DbContext
    {
        public ApexaContext(DbContextOptions<ApexaContext> options) : base(options)
        {}

        public DbSet<Advisor> Advisors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion<double>();
                    }
                }
            }

            modelBuilder.Entity<Advisor>()
            .Property(o => o.HealthStatus)
            .HasConversion(
                v => v.ToString(), // Store as string
                v => (HealthStatus)Enum.Parse(typeof(HealthStatus), v) // Convert back from string
            );
        }
    }
}