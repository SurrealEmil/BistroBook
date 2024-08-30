using BistroBook.Model;

namespace BistroBook.Date.Repositories.IRepositories
{
    public interface ITableRepository
    {
        // Create a new table
        Task AddTableAsync(Table table);

        // Read operations
        Task<Table> GetTableByIdAsync(int tableId);
        Task<IEnumerable<Table>> GetAllTablesAsync();

        // Update an existing table
        Task UpdateTableAsync(Table table);

        // Delete a table
        Task DeleteTableAsync(Table table);
    }
}
