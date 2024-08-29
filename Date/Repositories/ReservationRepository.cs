using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BistroBook.Date.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BistroBookContext _context;

        public ReservationRepository(BistroBookContext context)
        {
            _context = context;
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null) 
            {
                _context.Reservations.Remove(reservation);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            var reservationList = await _context.Reservations
                .Include(r => r.Customer)   // Eager load Customer
                .Include(r => r.Table)      // Eager load Table
                .ToListAsync();
            return reservationList;
        }

        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Customer)   // Eager load Customer
                .Include(r => r.Table)      // Eager load Table
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync(int tableId, TimeSpan startTime, TimeSpan endTime)
        {
            var checkReservation = await _context.Reservations
                .Where(r => r.FK_TableId == tableId &&
                            r.StartTime < endTime &&
                            r.EndTime > startTime)
                .ToListAsync();
            return checkReservation;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerIdAsync(int customerId)
        {
            var reservationCustomer = await _context.Reservations
                .Include(r => r.Customer)  // Eager load Customer
                .Include(r => r.Table)     // Eager load Table
                .Where(r => r.FK_CustomerId == customerId)
                .ToListAsync();
            return reservationCustomer;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime date)
        {
            var reservationDate = await _context.Reservations
                .Include(r => r.Customer)  // Eager load Customer
                .Include(r => r.Table)     // Eager load Table
                .Where(r => r.Date.Date == date.Date)
                .ToListAsync();
            return reservationDate;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByTableIdAsync(int tableId)
        {
            var reservationTable = await _context.Reservations
                .Include(r => r.Customer)  // Eager load Customer
                .Include(r => r.Table)     // Eager load Table
                .Where(r => r.FK_TableId == tableId)
                .ToListAsync();
            return reservationTable;
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
