using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Model;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BistroBook.Model.DTOs.TableDTOs;
using Microsoft.IdentityModel.Tokens;

namespace BistroBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        // Get /api/Tables/GetAllTables
        [HttpGet]
        [Route("GetAllTables")]
        public async Task<ActionResult<IEnumerable<TableSummaryDto>>> GetAllTables()
        {
            var tableList = await _tableService.GetAllTablesAsync();

            if (tableList.IsNullOrEmpty())
            {
                return NotFound("No tables found.");
            }

            return Ok(tableList);
        }

        // Get /api/Tables/GetAvailableTables
        [HttpGet]
        [Route("GetAvailableTables/{guestCount}")]
        public async Task<ActionResult<IEnumerable<TableSummaryDto>>> GetAvailableTables(int guestCount)
        {
            var availableTables = await _tableService.GetAvailableTablesAsync(guestCount);

            if (availableTables.IsNullOrEmpty())
            {
                return NotFound("No tables found.");
            }

            return Ok(availableTables);
        }

        // Get /api/Tables/GetTableById/{id}
        [HttpGet]
        [Route("GetTableById/{id}")]
        public async Task<ActionResult<TableDetailDto>> GetTableById(int id)
        {
            var table = await _tableService.GetTableByIdAsync(id);

            if (table == null)
            {
                return NotFound("No matching table found.");
            }

            return Ok(table);
        }

        // Post /api/Tables/AddTable
        [HttpPost]
        [Route("AddTable")]
        public async Task<ActionResult> AddTable([FromBody] TableCreateDto tabel)
        {
            try
            {
                await _tableService.AddTableAsync(tabel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Table added successfully.");
        }

        // Put /api/Tables/UpdateTable/{id}
        [HttpPut]
        [Route("UpdateTable/{id}")]
        public async Task<ActionResult> UpdateTable(int id, [FromBody] TableUpdateDto tabel)
        {
            try
            {
                await _tableService.UpdateTableAsync(id, tabel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Table updated successfully.");
        }

        // Delete /api/Tables/DeleteTable/{id}
        [HttpDelete]
        [Route("DeleteTable/{id}")]
        public async Task<ActionResult> DeleteTable(int id)
        {
            try
            {
                await _tableService.DeleteTableAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Table deleted successfully.");
        }
    }
}
