using BistroBook.Model;

namespace BistroBook.Date.Repositories.IRepositories
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<Table> GetTableByIdAsync(int tableId);
        Task AddTableAsync(Table table);
        Task UpdateTableAsync(Table table);
        Task DeleteTableAsync(int tableId);
    }
}
