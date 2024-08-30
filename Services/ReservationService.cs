using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using BistroBook.Model.DTOs.ReservationDTOs;
using BistroBook.Services.IServices;

namespace BistroBook.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITableRepository _tableRepository;

        public ReservationService(
        IReservationRepository reservationRepository,
        ICustomerRepository customerRepository,
        ITableRepository tableRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _tableRepository = tableRepository;
        }

        // Add a new reservation
        public async Task AddReservationAsync(ReservationCreateDto reservationDto)
        {
            // Validate the customer and table
            await ValidateCustomerAndTableAsync(reservationDto.CustomerId, reservationDto.TableId);

            // Validate guest count and check for conflicts
            await ValidateReservationDetailsAsync(reservationDto.GuestCount, reservationDto.TableId, reservationDto.Date, reservationDto.StartTime, reservationDto.EndTime);

            // Create and add the reservation
            var reservation = new Reservation
            {
                FK_CustomerId = reservationDto.CustomerId,
                FK_TableId = reservationDto.TableId,
                GuestCount = reservationDto.GuestCount,
                Date = reservationDto.Date,
                StartTime = reservationDto.StartTime,
                EndTime = reservationDto.EndTime
            };

            await _reservationRepository.AddReservationAsync(reservation);
        }

        // Delete a reservation by its ID
        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);
            if (reservation == null)
            {
                throw new InvalidOperationException("Reservation not found");
            }

            await _reservationRepository.DeleteReservationAsync(reservation);
        }

        // Get all reservations and map to summary DTOs
        public async Task<IEnumerable<ReservationSummaryDto>> GetAllReservationsAsync()
        {
            var reservationList = await _reservationRepository.GetAllReservationsAsync();
            return reservationList.Select(r => new ReservationSummaryDto
            {
                ReservationId = r.ReservationId,
                CustomerId = r.FK_CustomerId,
                CustomerFullName = $"{r.Customer.FirstName} {r.Customer.LastName}",
                TableId = r.FK_TableId,
                TableNumber = r.Table.TableNumber,
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
            }).ToList();
        }

        public async Task<ReservationDetailDto> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);
            if (reservation == null)
            {
                return null;
            }

            return new ReservationDetailDto
            {
                ReservationId = reservation.ReservationId,
                TableId = reservation.FK_TableId,
                TableNumber = reservation.Table.TableNumber,
                CustomerId = reservation.FK_CustomerId,
                GuestCount = reservation.GuestCount,
                CustomerFullName = $"{reservation.Customer.FirstName} {reservation.Customer.LastName}",
                Date = reservation.Date,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
            };
        }

        // Get all reservations connected to a specific customer {id} and map to summary DTOs
        public async Task<IEnumerable<ReservationSummaryDto>> GetReservationsByCustomerIdAsync(int customerId)
        {
            var reservations = await _reservationRepository.GetReservationsByCustomerIdAsync(customerId);
            return reservations.Select(r => new ReservationSummaryDto
            {
                ReservationId = r.ReservationId,
                TableId = r.FK_TableId,
                TableNumber = r.Table.TableNumber,
                CustomerId = r.FK_CustomerId,
                CustomerFullName = $"{r.Customer.FirstName} {r.Customer.LastName}",
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
            }).ToList();
        }

        // Get all reservations connected to a specific date and map to summary DTOs
        public async Task<IEnumerable<ReservationSummaryDto>> GetReservationsByDateAsync(DateTime date)
        {
            var reservations = await _reservationRepository.GetReservationsByDateAsync(date);
            return reservations.Select(r => new ReservationSummaryDto
            {
                ReservationId = r.ReservationId,
                TableId = r.FK_TableId,
                TableNumber = r.Table.TableNumber,
                CustomerId = r.FK_CustomerId,
                CustomerFullName = $"{r.Customer.FirstName} {r.Customer.LastName}",
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
            }).ToList();
        }

        // Get all reservations connected to a specific table {id} and map to summary DTOs
        public async Task<IEnumerable<ReservationSummaryDto>> GetReservationsByTableIdAsync(int tableId)
        {
            var reservations = await _reservationRepository.GetReservationsByTableIdAsync(tableId);
            return reservations.Select(r => new ReservationSummaryDto
            {
                ReservationId = r.ReservationId,
                TableId = r.FK_TableId,
                TableNumber = r.Table.TableNumber,
                CustomerId = r.FK_CustomerId,
                CustomerFullName = $"{r.Customer.FirstName} {r.Customer.LastName}",
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
            }).ToList();
        }

        // Update an existing reservation by its ID
        public async Task UpdateReservationAsync(int reservationId, ReservationUpdateDto reservationDto)
        {
            // Fetch and validate the existing reservation
            var existingReservation = await GetExistingReservationAsync(reservationId);

            // Validate the customer and table
            await ValidateCustomerAndTableAsync(reservationDto.CustomerId, reservationDto.TableId);

            // Validate guest count and check for conflicts
            await ValidateReservationDetailsAsync(reservationDto.GuestCount, reservationDto.TableId, reservationDto.Date, reservationDto.StartTime, reservationDto.EndTime, reservationId);

            // Update reservation details
            UpdateReservation(existingReservation, reservationDto);

            await _reservationRepository.UpdateReservationAsync(existingReservation);
        }

        // Helper methods

        private async Task<Reservation> GetExistingReservationAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);
            if (reservation == null)
            {
                throw new InvalidOperationException("Reservation was not found.");
            }
            return reservation;
        }

        private async Task ValidateCustomerAndTableAsync(int customerId, int tableId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer was not found.");
            }

            var table = await _tableRepository.GetTableByIdAsync(tableId);
            if (table == null)
            {
                throw new InvalidOperationException("Table was not found.");
            }
        }

        private async Task ValidateReservationDetailsAsync(int guestCount, int tableId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? reservationId = null)
        {
            var table = await _tableRepository.GetTableByIdAsync(tableId);
            if (guestCount > table.SeatCount)
            {
                throw new ArgumentException("The number of guests exceeds the available seats at the table.");
            }

            var conflictingReservations = await _reservationRepository.GetReservationsAsync(tableId, date, startTime, endTime, reservationId);
            if (conflictingReservations.Any())
            {
                throw new InvalidOperationException("The table is already reserved for the selected time slot.");
            }
        }

        private void UpdateReservation(Reservation existingReservation, ReservationUpdateDto reservationDto)
        {
            existingReservation.FK_CustomerId = reservationDto.CustomerId;
            existingReservation.FK_TableId = reservationDto.TableId;
            existingReservation.GuestCount = reservationDto.GuestCount;
            existingReservation.Date = reservationDto.Date;
            existingReservation.StartTime = reservationDto.StartTime;
            existingReservation.EndTime = reservationDto.EndTime;
        }
    }
}
