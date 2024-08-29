using BistroBook.Model.DTOs.ReservationDTOs;

namespace BistroBook.Services.IServices
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationSummaryDto>> GetAllReservationsAsync();
        Task<ReservationDetailDto> GetReservationByIdAsync(int reservationId);
        Task AddReservationAsync(ReservationCreateDto reservation);
        Task UpdateReservationAsync(int reservationId, ReservationUpdateDto reservation);
        Task DeleteReservationAsync(int reservationId);

        Task<IEnumerable<ReservationSummaryDto>> GetReservationsByCustomerIdAsync(int customerId);
        Task<IEnumerable<ReservationSummaryDto>> GetReservationsByTableIdAsync(int tableId);
        Task<IEnumerable<ReservationSummaryDto>> GetReservationsByDateAsync(DateTime date);
    }
}
