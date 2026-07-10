using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventHub_MVC.Models;

namespace EventHub_MVC.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Date).IsRequired();

            builder.HasOne(e => e.Venue)
                   .WithMany(v => v.Events)
                   .HasForeignKey(e => e.VenueId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}