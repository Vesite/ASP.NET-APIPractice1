using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockControllers : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepo; // This variable is basically the server i guess
        public StockControllers(IStockRepository stockRepo, ApplicationDbContext context)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var stocks = await _stockRepo.GetAllAsync(query);
            
            var stockDto = stocks.Select(s => s.ToStockDto()).ToList(); // Select is the same as Map

            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
                return NotFound();
            

            return Ok(stock.ToStockDto());
        }

        [HttpPost] // Create
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockRepo.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut] // Update
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            // Find the row we will edit
            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if (stockModel == null)
                return NotFound();
            
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var stockModel = await _stockRepo.DeleteAsync(id);

            if (stockModel == null)
                return NotFound();

            return NoContent();
        }

    }
}