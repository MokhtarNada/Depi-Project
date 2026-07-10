using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventHub_MVC.Models;

namespace EventHub_MVC.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(t => t.Price).HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.Booking)
                   .WithMany()
                   .HasForeignKey(t => t.BookingId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}