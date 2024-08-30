using BistroBook.Model;
using BistroBook.Model.DTOs.ReservationDTOs;

namespace BistroBook.Date.Repositories.IRepositories
{
    public interface IReservationRepository
    {
        // Create a new reservation
        Task AddReservationAsync(Reservation reservationDto);

        // Read operations
        Task<Reservation> GetReservationByIdAsync(int reservationId);
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime date);
        Task<IEnumerable<Reservation>> GetReservationsByTableIdAsync(int tableId);
        Task<IEnumerable<Reservation>> GetReservationsByCustomerIdAsync(int customerId);
        Task<IEnumerable<Reservation>> GetReservationsAsync(int tableId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? reservationId = null);

        // Update an existing reservation
        Task UpdateReservationAsync(Reservation reservation);

        // Delete a reservation
        Task DeleteReservationAsync(Reservation reservation);  
    }
}
