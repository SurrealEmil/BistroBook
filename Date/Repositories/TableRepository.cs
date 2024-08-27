using BistroBook.Date.Repositories.IRepositories;
using BistroBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BistroBook.Date.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly BistroBookContext _context;

        public TableRepository(BistroBookContext context)
        {
            _context = context;
        }

        public async Task AddTableAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table != null)
            {
                _context.Tables.Remove(table);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            var tableList = await _context.Tables.ToListAsync();
            return tableList;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            return table;
        }

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }
    }
}
