﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BistroBook.Model.DTOs.ReservationDTOs
{
    public class ReservationUpdateDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TableId { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Guest count must be between 1 and 20.")]
        public int GuestCount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
    }
}
