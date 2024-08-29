using BistroBook.Model.DTOs.ReservationDTOs;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BistroBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Route("GetAllReservations")]
        public async Task<ActionResult<IEnumerable<ReservationSummaryDto>>> GetAllReservations()
        {
            var reservationList = await _reservationService.GetAllReservationsAsync();
            return Ok(reservationList);
        }

        [HttpGet]
        [Route("GetReservationById/{reservationId}")]
        public async Task<ActionResult<ReservationDetailDto>> GetReservationById(int reservationId)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(reservationId);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        [Route("AddReservation")]
        public async Task<ActionResult> AddReservation([FromBody] ReservationCreateDto reservation)
        {
            try
            {
                await _reservationService.AddReservationAsync(reservation);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateReservation/{reservationId}")]
        public async Task<ActionResult> UpdateReservation(int reservationId, [FromBody] ReservationUpdateDto reservation)
        {
            try
            {
                await _reservationService.UpdateReservationAsync(reservationId, reservation);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteReservation/{reservationId}")]
        public async Task<ActionResult> DeleteReservation(int reservationId)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(reservationId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Reservations/GetReservationsByCustomerId/5
        [HttpGet]
        [Route("GetReservationsByCustomerId/{customerId}")]
        public async Task<ActionResult<IEnumerable<ReservationSummaryDto>>> GetReservationsByCustomerId(int customerId)
        {
            var reservations = await _reservationService.GetReservationsByCustomerIdAsync(customerId);
            return Ok(reservations);
        }

        // GET: api/Reservations/GetReservationsByTableId/5
        [HttpGet]
        [Route("GetReservationsByTableId/{tableId}")]
        public async Task<ActionResult<IEnumerable<ReservationSummaryDto>>> GetReservationsByTableId(int tableId)
        {
            var reservations = await _reservationService.GetReservationsByTableIdAsync(tableId);
            return Ok(reservations);
        }

        // GET: api/Reservations/GetReservationsByDate/2024-08-29
        [HttpGet]
        [Route("GetReservationsByDate/{date}")]
        public async Task<ActionResult<IEnumerable<ReservationSummaryDto>>> GetReservationsByDate(DateTime date)
        {
            var reservations = await _reservationService.GetReservationsByDateAsync(date);
            return Ok(reservations);
        }
    }
}
