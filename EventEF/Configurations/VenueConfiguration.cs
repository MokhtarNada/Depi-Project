using EventEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventEF.Configurations
{
    internal class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Location)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}