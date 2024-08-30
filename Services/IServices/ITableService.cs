using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Model.DTOs.TableDTOs;

namespace BistroBook.Services.IServices
{
    public interface ITableService
    {
        // Create a new table
        Task AddTableAsync(TableCreateDto table);

        // Read operations
        Task<TableDetailDto> GetTableByIdAsync(int tableId);
        Task<IEnumerable<TableSummaryDto>> GetAllTablesAsync();

        // Update an existing table
        Task UpdateTableAsync(int tableId, TableUpdateDto table);

        // Delete a table
        Task DeleteTableAsync(int tableId);
    }
}
