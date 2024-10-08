﻿using System.ComponentModel.DataAnnotations;

namespace BistroBook.Model.DTOs.ReservationDTOs
{
    public class ReservationDetailDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int CustomerId { get; set; }
        public int GuestCount { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
