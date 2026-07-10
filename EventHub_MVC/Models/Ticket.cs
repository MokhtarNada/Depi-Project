namespace EventHub_MVC.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}