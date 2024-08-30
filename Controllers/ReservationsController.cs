using BistroBook.Model.DTOs.ReservationDTOs;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        // Get /api/Reservations/GetAllReservations
        [HttpGet]
        [Route("GetAllReservations")]
        public async Task<ActionResult<IEnumerable<ReservationSummaryDto>>> GetAllReservations()
        {
            var reservationList = await _reservationService.GetAllReservationsAsync();

            if (reservationList.IsNullOrEmpty())
            {
                return StatusCode(404, "No reservations found.");
            }

            return Ok(reservationList);
        }

        // Get /api/Reservations/GetReservationById/{id}
        [HttpGet]
        [Route("GetReservationById/{id}")]
        public async Task<ActionResult<ReservationDetailDto>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);

            if (reservation == null)
            {
                return StatusCode(404, "No matching reservation found.");
            }

            return Ok(reservation);
        }

        // Post /api/Reservations/AddReservation
        [HttpPost]
        [Route("AddReservation")]
        public async Task<ActionResult> AddReservation([FromBody] ReservationCreateDto reservation)
        {
            try
            {
                await _reservationService.AddReservationAsync(reservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Reservation added successfully.");
        }

        // Put /api/Reservations/UpdateReservation/{id}
        [HttpPut]
        [Route("UpdateReservation/{id}")]
        public async Task<ActionResult> UpdateReservation(int id, [FromBody] ReservationUpdateDto reservation)
        {
            try
            {
                await _reservationService.UpdateReservationAsync(id, reservation); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Reservation updated successfully.");
        }

        // Delete /api/Reservations/DeleteReservation/{id}
        [HttpDelete]
        [Route("DeleteReservation/{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Reservation deleted successfully.");
        }

        // GET: api/Reservations/GetReservationsByCustomerId/{id}
        [HttpGet]
        [Route("GetReservationsByCustomerId/{id}")]
        public async Task<ActionResult<IEnumerable<ReservationSummaryDto>>> GetReservationsByCustomerId(int id)
        {
            var reservations = await _reservationService.GetReservationsByCustomerIdAsync(id);

            if (reservations.IsNullOrEmpty())
            {
                return StatusCode(404, "No reservations found.");
            }   

            return Ok(reservations);
        }

        // GET: api/Reservations/GetReservationsByTableId/{id}
        [HttpGet]
        [Route("GetReservationsByTableId/{id}")]
        public async Task<ActionResult<IEnumerable<ReservationSummaryDto>>> GetReservationsByTableId(int id)
        {
            var reservations = await _reservationService.GetReservationsByTableIdAsync(id);

            if (reservations.IsNullOrEmpty())
            {
                return StatusCode(404, "No reservations found.");
            }  

            return Ok(reservations);
        }

        // GET: api/Reservations/GetReservationsByDate/2024-08-30
        [HttpGet]
        [Route("GetReservationsByDate/{date}")]
        public async Task<ActionResult<IEnumerable<ReservationSummaryDto>>> GetReservationsByDate(DateTime date)
        {
            var reservations = await _reservationService.GetReservationsByDateAsync(date);

            if (reservations.IsNullOrEmpty())
            {
                return StatusCode(404, "No reservations found.");
            }

            return Ok(reservations);
        }
    }
}
