using BistroBook.Model;
using BistroBook.Model.DTOs.ReservationDTOs;

namespace BistroBook.Services.IServices
{
    public interface IReservationService
    {
        // Create a new reservation
        Task AddReservationAsync(ReservationCreateDto reservation);

        // Read operations
        Task<ReservationDetailDto> GetReservationByIdAsync(int reservationId);
        Task<IEnumerable<ReservationSummaryDto>> GetAllReservationsAsync();
        Task<IEnumerable<ReservationSummaryDto>> GetReservationsByDateAsync(DateTime date);
        Task<IEnumerable<ReservationSummaryDto>> GetReservationsByTableIdAsync(int tableId);
        Task<IEnumerable<ReservationSummaryDto>> GetReservationsByTableIdAndDateAsync(int tableId, DateTime date);
        Task<IEnumerable<ReservationSummaryDto>> GetReservationsByCustomerIdAsync(int customerId);

        // Update an existing reservation
        Task UpdateReservationAsync(ReservationUpdateDto reservation);

        // Delete a reservation
        Task DeleteReservationAsync(int reservationId);
    }
}
