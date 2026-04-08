using EventEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventEF.Configurations
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.Booking)
                   .WithMany()
                   .HasForeignKey(t => t.BookingId);
        }
    }
}