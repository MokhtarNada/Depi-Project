using EventEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventEF.Configurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.NumberOfTickets)
                   .IsRequired();

            builder.Property(b => b.BookingDate)
                   .IsRequired();

            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bookings)
                   .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Event)
                   .WithMany(e => e.Bookings)
                   .HasForeignKey(b => b.EventId);
        }
    }
}