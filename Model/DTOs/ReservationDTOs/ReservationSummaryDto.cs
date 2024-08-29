namespace BistroBook.Model.DTOs.ReservationDTOs
{
    public class ReservationSummaryDto
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public string CustomerFullName { get; set; }
        public int TableNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
