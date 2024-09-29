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

        // Add a new table
        public async Task AddTableAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        // Delete a table by its ID
        public async Task DeleteTableAsync(Table table)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        // Get all tables
        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            var tableList = await _context.Tables.ToListAsync();
            return tableList;
        }

        public async Task<IEnumerable<Table>> GetAvailableTablesAsync(int guestCount)
        {
            var availableTables = await _context.Tables
            .Where(t => t.SeatCount >= guestCount)
            .ToListAsync();
            return availableTables;
        }

        // Get a table by its ID
        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            return table;
        }

        // Update a customer by its ID
        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }
    }
}
