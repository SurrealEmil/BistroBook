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

        // Add a new reservation
        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        // Delete a reservation by its ID
        public async Task DeleteReservationAsync(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        // Get all reservations with related Customer and Table
        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            var reservationList = await GetReservationsWithDetails()
                .ToListAsync();
            return reservationList;
        }

        // Get a specific reservation by its ID with related Customer and Table
        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await GetReservationsWithDetails()
                .FirstOrDefaultAsync(r => r.Id == reservationId);
            return reservation;
        }

        // Get reservations for a specific table within a time range
        public async Task<IEnumerable<Reservation>> GetReservationsAsync(int tableId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? reservationId = null)
        {
            var reservations = await _context.Reservations
                .Where(r => r.FK_TableId == tableId &&
                            r.Date == date && // Ensure that only the same date is checked
                            r.Id != reservationId && // Exclude the reservation being updated
                            r.StartTime < endTime &&
                            r.EndTime > startTime)
                .ToListAsync();

            return reservations;
        }

        // Get reservations for a specific customer
        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerIdAsync(int customerId)
        {
            var reservationCustomer = await GetReservationsWithDetails()
                .Where(r => r.FK_CustomerId == customerId)
                .ToListAsync();
            return reservationCustomer;
        }

        // Get reservations for a specific date
        public async Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime date)
        {
            var reservationDate = await GetReservationsWithDetails()
                .Where(r => r.Date.Date == date.Date)
                .ToListAsync();
            return reservationDate;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByTableIdAndDateAsync(int tableId, DateTime date)
        {
            var reservationDateAndTable = await GetReservationsWithDetails()
                .Where(r => r.Date.Date == date.Date && r.FK_TableId == tableId)
                .ToListAsync();
            return reservationDateAndTable;
        }

        // Get reservations for a specific table
        public async Task<IEnumerable<Reservation>> GetReservationsByTableIdAsync(int tableId)
        {
            var reservationTable = await GetReservationsWithDetails()
                .Where(r => r.FK_TableId == tableId)
                .ToListAsync();
            return reservationTable;
        }

        public async Task<bool> IsTableAvailableAsync(int tableId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? reservationIdToIgnore)
        {
            return await _context.Reservations
                    .AnyAsync(r => r.FK_TableId == tableId &&
                                   r.Date == date &&
                                   r.Id != reservationIdToIgnore &&
                                   r.StartTime < endTime &&
                                   r.EndTime > startTime);
        }

        public async Task<bool> IsTableAvailableAsync(int tableId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            return await _context.Reservations
                    .AnyAsync(r => r.FK_TableId == tableId &&
                                   r.Date == date &&
                                   r.StartTime < endTime &&
                                   r.EndTime > startTime);
        }

        // Update an existing reservation
        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        // Helper method to include related entities
        private IQueryable<Reservation> GetReservationsWithDetails()
        {
            return _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Table);
        }
    }
}
