using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using BistroBook.Model.DTOs.ReservationDTOs;
using BistroBook.Services.IServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task AddReservationAsync(ReservationCreateDto reservation)
        {
            // Check availability of the table
            var theTable = await _tableRepository.GetTableByIdAsync(reservation.TableId);
            if (theTable == null)
            {
                throw new InvalidOperationException($"Table {reservation.TableId} not found!");
            }

            // Calculate the reservation end time
            var resEndTime = reservation.StartTime.Add(new TimeSpan(2, 0, 0));

            // Check if the table is busy during the requested time
            var isTableBusy = await _reservationRepository.IsTableAvailableAsync(reservation.TableId, reservation.Date, reservation.StartTime, resEndTime);

            if (isTableBusy)
            {
                throw new InvalidOperationException($"Table {reservation.TableId} is not available at the selected time.");
            }

            // Error check for number of guests
            if (reservation.GuestCount < 1 || reservation.GuestCount > 20)
            {
                throw new InvalidOperationException($"Guest count must be between 1 and 20.");
            }

            // Check if the customer already exists, or create a new customer
            var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(reservation.Email);
            Customer customer;

            if (existingCustomer == null)
            {
                customer = new Customer
                {
                    FirstName = reservation.FirstName,
                    LastName = reservation.LastName,
                    PhoneNumber = reservation.PhoneNumber,
                    Email = reservation.Email
                };
                await _customerRepository.AddCustomerAsync(customer);
            }
            else
            {
                customer = existingCustomer;
            }

            // Create a new reservation
            var newRes = new Reservation
            {
                GuestCount = reservation.GuestCount,
                Date = reservation.Date,
                StartTime = reservation.StartTime,
                EndTime = resEndTime,
                FK_CustomerId = customer.Id,
                FK_TableId = reservation.TableId,
            };

            // Save the booking
            await _reservationRepository.AddReservationAsync(newRes);
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
                Id = r.Id,
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
                Id = reservation.Id,
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
                Id = r.Id,
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
                Id = r.Id,
                TableId = r.FK_TableId,
                TableNumber = r.Table.TableNumber,
                CustomerId = r.FK_CustomerId,
                CustomerFullName = $"{r.Customer.FirstName} {r.Customer.LastName}",
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
            }).ToList();
        }

        public async Task<IEnumerable<ReservationSummaryDto>> GetReservationsByTableIdAndDateAsync(int tableId, DateTime date)
        {
            var reservations = await _reservationRepository.GetReservationsByTableIdAndDateAsync(tableId, date);
            return reservations.Select(r => new ReservationSummaryDto
            {
                Id = r.Id,
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
                Id = r.Id,
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
        public async Task UpdateReservationAsync(ReservationUpdateDto reservationDto)
        {
            // Retrieve the existing reservation
            var existingReservation = await _reservationRepository.GetReservationByIdAsync(reservationDto.Id);
            if (existingReservation == null)
            {
                throw new InvalidOperationException($"Reservation {reservationDto.Id} not found!");
            }

            // Check availability of the table
            var theTable = await _tableRepository.GetTableByIdAsync(reservationDto.TableId);
            if (theTable == null)
            {
                throw new InvalidOperationException($"Table {reservationDto.TableId} not found!");
            }

            // Calculate the new reservation end time
            var newEndTime = reservationDto.StartTime.Add(new TimeSpan(2, 0, 0));

            // Check if the table is busy during the requested time
            var isTableBusy = await _reservationRepository.IsTableAvailableAsync(reservationDto.TableId, reservationDto.Date, reservationDto.StartTime, newEndTime, existingReservation.Id);

            if (isTableBusy)
            {
                throw new InvalidOperationException($"Table {reservationDto.TableId} is not available at the selected time.");
            }

            // Error check for number of guests
            if (reservationDto.GuestCount < 1 || reservationDto.GuestCount > 20)
            {
                throw new InvalidOperationException($"Guest count must be between 1 and 20.");
            }

            // Update the existing reservation
            existingReservation.GuestCount = reservationDto.GuestCount;
            existingReservation.Date = reservationDto.Date;
            existingReservation.StartTime = reservationDto.StartTime;
            existingReservation.EndTime = newEndTime; // Set the new end time
            existingReservation.FK_TableId = reservationDto.TableId;

            // Save the changes
            await _reservationRepository.UpdateReservationAsync(existingReservation);
        }
    }
}
