using EventEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventEF.Configurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Description)
                   .HasMaxLength(500);

            builder.Property(e => e.Date)
                   .IsRequired();

            builder.Property(e => e.Capacity)
                   .IsRequired();

            builder.HasOne(e => e.Venue)
                   .WithMany(v => v.Events)
                   .HasForeignKey(e => e.VenueId);
        }
    }
}