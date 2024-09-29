using BistroBook.Date.Repositories;
using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using BistroBook.Model.DTOs.TableDTOs;
using BistroBook.Services.IServices;

namespace BistroBook.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        // Add a new table
        public async Task AddTableAsync(TableCreateDto table)
        {
            var newTable = new Table
            {
                TableNumber = table.TableNumber,
                SeatCount = table.SeatCount,
            };
            await _tableRepository.AddTableAsync(newTable);
        }

        // Delete a table by its ID
        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _tableRepository.GetTableByIdAsync(tableId);
            if (table == null)
            {
                throw new InvalidOperationException("Table was not found.");
            }
            await _tableRepository.DeleteTableAsync(table);
        }

        // Get all tables and map to summary DTOs
        public async Task<IEnumerable<TableSummaryDto>> GetAllTablesAsync()
        {
            var tableList = await _tableRepository.GetAllTablesAsync();
            return tableList.Select(t => new TableSummaryDto
            {
                Id = t.Id,
                TableNumber = t.TableNumber,
                SeatCount = t.SeatCount,
            }).ToList();
        }

        public async Task<IEnumerable<TableSummaryDto>> GetAvailableTablesAsync(int guestCount)
        {
            var availableTables = await _tableRepository.GetAvailableTablesAsync(guestCount);
            return availableTables.Select(t => new TableSummaryDto
            {
                Id = t.Id,
                TableNumber = t.TableNumber,
                SeatCount = t.SeatCount,
            }).ToList();
        }

        // Get a table by its ID and map to detail DTO
        public async Task<TableDetailDto> GetTableByIdAsync(int tableId)
        {
            var table = await _tableRepository.GetTableByIdAsync(tableId);
            if (table == null)
            {
                return null;
            }

            return new TableDetailDto
            {
                Id = table.Id,
                TableNumber = table.TableNumber,
                SeatCount = table.SeatCount,
            };
        }

        // Update an existing table by its ID
        public async Task UpdateTableAsync(int tableId, TableUpdateDto table)
        {
            var updateTable = await _tableRepository.GetTableByIdAsync(tableId);
            if (updateTable == null)
            {
                throw new InvalidOperationException("Table was not found.");
            }

            updateTable.TableNumber = table.TableNumber;
            updateTable.SeatCount = table.SeatCount;
            
            await _tableRepository.UpdateTableAsync(updateTable);
        }
    }
}
