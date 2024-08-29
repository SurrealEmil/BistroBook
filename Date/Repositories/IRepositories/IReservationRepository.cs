using BistroBook.Model;
using BistroBook.Model.DTOs.ReservationDTOs;

namespace BistroBook.Date.Repositories.IRepositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int reservationId);
        Task AddReservationAsync(Reservation reservationDto);
        Task UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(int reservationId);


        Task<IEnumerable<Reservation>> GetReservationsAsync(int tableId, TimeSpan startTime, TimeSpan endTime);
        Task<IEnumerable<Reservation>> GetReservationsByCustomerIdAsync(int customerId);
        Task<IEnumerable<Reservation>> GetReservationsByTableIdAsync(int tableId);
        Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime date);
    }
}
