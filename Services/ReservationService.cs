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

        public async Task AddReservationAsync(ReservationCreateDto reservationDto)
        {

            // Validate the customer
            var customer = await _customerRepository.GetCustomerByIdAsync(reservationDto.CustomerId);
            if (customer == null)
            {
                throw new ArgumentException("Invalid customer ID");
            }


            // Validate the table
            var table = await _tableRepository.GetTableByIdAsync(reservationDto.TableId);
            if (table == null)
            {
                throw new ArgumentException("Invalid table ID");
            }


            // Validate the guest count
            if (reservationDto.GuestCount > table.SeatCount)
            {
                throw new ArgumentException("The number of guests exceeds the available seats at the table.");
            }

            // Check for overlapping reservations
            var conflictingReservations = await _reservationRepository.GetReservationsAsync(reservationDto.TableId, reservationDto.StartTime, reservationDto.EndTime);
            if (conflictingReservations.Any())
            {
                throw new InvalidOperationException("The table is already reserved for the selected time slot.");
            }

            var reservation = new Reservation
            {
                FK_CustomerId = reservationDto.CustomerId,
                FK_TableId = reservationDto.TableId,
                GuestCount = reservationDto.GuestCount,
                Date = reservationDto.Date,
                StartTime = reservationDto.StartTime,
                EndTime = reservationDto.EndTime,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _reservationRepository.AddReservationAsync(reservation);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found");
            }

            await _reservationRepository.DeleteReservationAsync(reservationId);
        }

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
                StartTime= r.StartTime,
                EndTime= r.EndTime,
                Status = r.Status,
            }).ToList();
        }

        public async Task<ReservationDetailDto> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId);
            if(reservation == null)
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
                Status = reservation.Status,
                CreatedAt = reservation.CreatedAt,
                UpdatedAt = reservation.UpdatedAt,
            };
        }

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
                Status = r.Status
            }).ToList();
        }

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
                Status = r.Status
            }).ToList();
        }

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
                Status = r.Status
            }).ToList();
        }

        public async Task UpdateReservationAsync(int reservationId, ReservationUpdateDto reservation)
        {
            var existingReservation = await _reservationRepository.GetReservationByIdAsync(reservationId);
            if (existingReservation == null)
            {
                throw new ArgumentException("Reservation not found");
            }

            var customer = await _customerRepository.GetCustomerByIdAsync(reservation.CustomerId);
            if (customer == null)
            {
                throw new ArgumentException("Invalid customer ID");
            }

            var table = await _tableRepository.GetTableByIdAsync(reservation.TableId);
            if (table == null)
            {
                throw new ArgumentException("Invalid table ID");
            }

            existingReservation.FK_CustomerId = reservation.CustomerId;
            existingReservation.FK_TableId = reservation.TableId;
            existingReservation.Date = reservation.Date;
            existingReservation.StartTime = reservation.StartTime;
            existingReservation.EndTime = reservation.EndTime;
            existingReservation.Status = reservation.Status;
            existingReservation.UpdatedAt = DateTime.UtcNow;

            await _reservationRepository.UpdateReservationAsync(existingReservation);
        }
    }
}
