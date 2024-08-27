using BistroBook.Model.DTOs.CustomerDTOs;
using BistroBook.Model;
using BistroBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BistroBook.Model.DTOs.TableDTOs;

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

        [HttpGet]
        [Route("GetAllTables")]
        public async Task<ActionResult<IEnumerable<Table>>> GetAllTables()
        {
            var tableList = await _tableService.GetAllTablesAsync();
            return Ok(tableList);
        }

        [HttpGet]
        [Route("GetTableById/{tableId}")]
        public async Task<ActionResult<Table>> GetTableById(int tableId)
        {
            var table = await _tableService.GetTableByIdAsync(tableId);
            return Ok(table);
        }

        [HttpPost]
        [Route("AddTable")]
        public async Task<ActionResult> AddTable([FromBody] TableCreateDto tabel)
        {
            await _tableService.AddTableAsync(tabel);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateTable/{tableId}")]
        public async Task<ActionResult> UpdateTable(int tableId, [FromBody] TableUpdateDto tabel)
        {
            await _tableService.UpdateTableAsync(tableId, tabel);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteTable/{tableId}")]
        public async Task<ActionResult<Table>> DeleteTable([FromBody] int tableId)
        {
            await _tableService.DeleteTableAsync(tableId);
            return Ok();
        }
    }
}
