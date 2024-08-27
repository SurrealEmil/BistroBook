using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Model.DTOs.TableDTOs;

namespace BistroBook.Services.IServices
{
    public interface ITableService
    {
        Task<IEnumerable<TableSummaryDto>> GetAllTablesAsync();
        Task<TableDetailDto> GetTableByIdAsync(int tableId);
        Task AddTableAsync(TableCreateDto table);
        Task UpdateTableAsync(int tableId, TableUpdateDto table);
        Task DeleteTableAsync(int tableId);
    }
}
