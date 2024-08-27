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

        public async Task AddTableAsync(TableCreateDto table)
        {
            var newTable = new Table
            {
                TableNumber = table.TableNumber,
                SeatCount = table.SeatCount,
            };
            await _tableRepository.AddTableAsync(newTable);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            await _tableRepository.DeleteTableAsync(tableId);
        }

        public async Task<IEnumerable<TableSummaryDto>> GetAllTablesAsync()
        {
            var tableList = await _tableRepository.GetAllTablesAsync();
            return tableList.Select(t => new TableSummaryDto
            {
                TableId = t.TableId,
                TableNumber = t.TableNumber,
                SeatCount = t.SeatCount,
            }).ToList();
        }

        public async Task<TableDetailDto> GetTableByIdAsync(int tableId)
        {
            var table = await _tableRepository.GetTableByIdAsync(tableId);
            if (table == null)
            {
                return null;
            }

            return new TableDetailDto
            {
                TableId = table.TableId,
                TableNumber = table.TableNumber,
                SeatCount = table.SeatCount,
            };
        }

        public async Task UpdateTableAsync(int tableId, TableUpdateDto table)
        {
            var updateTable = await _tableRepository.GetTableByIdAsync(tableId);
            {
                updateTable.TableNumber = table.TableNumber;
                updateTable.SeatCount = table.SeatCount;
            };
            await _tableRepository.UpdateTableAsync(updateTable);
        }
    }
}
