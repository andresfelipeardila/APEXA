using ApexaApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApexaApp.API.Data.Config
{
    public class AdvisorConfiguration: IEntityTypeConfiguration<Advisor>
    {
        public void Configure(EntityTypeBuilder<Advisor> builder)
        {           
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(255);
            builder.Property(a => a.SIN).IsRequired().HasMaxLength(9);
            builder.Property(a => a.Address).HasMaxLength(255);
            builder.Property(a => a.Address).HasMaxLength(10);
            builder.Property(c => c.HealthStatus).ValueGeneratedOnAdd();
        }
    }
}