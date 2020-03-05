using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscInventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiscInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscController : ControllerBase
    {
        public DatabaseContext db { get; set; } = new DatabaseContext();

        [HttpGet("{locationId}")]
        public async Task<List<Disc>> GetAllDiscs(int locationId)
        {
            return await db.Discs.Where(d => d.LocationId == locationId).OrderBy(d => d.Name).ToListAsync();
        }
        [HttpGet("{id}/{locationId}")]
        public async Task<Disc> GetDiscById(int id, int locationId)
        {
            return await db.Discs.FirstOrDefaultAsync(d => d.Id == id && d.LocationId == locationId);
        }
        [HttpPost("locationId/{locationId}")]
        public async Task<Disc> AddDiscToInventory(Disc disc, int locationId)
        {
            disc.LocationId = locationId;
            await db.Discs.AddAsync(disc);
            await db.SaveChangesAsync();
            return disc;
        }
        [HttpPut("{id}/locationId/{locationId}")]
        public async Task<Disc> UpdateDiscInInventory(int id, Disc newDiscData, int locationId)
        {
            newDiscData.Id = id;
            newDiscData.LocationId = locationId;
            db.Entry(newDiscData).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return newDiscData;
        }


        [HttpDelete("{id}/locationId/{locationId}")]
        public async Task<ActionResult> DeleteDiscFromInventory(int id, int locationId)
        {

            var discToRemove = await db.Discs.FirstOrDefaultAsync(d => d.Id == id && d.LocationId == locationId);
            db.Discs.Remove(discToRemove);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("oos")]
        public async Task<List<Disc>> GetAllDiscsOutOfStock()
        {
            return await db.Discs.Where(d => d.NumberInStock == 0).ToListAsync();
        }
        [HttpGet("oos/locationId/{locationId}")]
        public async Task<List<Disc>> GetAllDiscsOutOfStockAtLocation(int locationId)
        {
            return await db.Discs.Where(d => d.NumberInStock == 0 && d.LocationId == locationId).ToListAsync();
        }
        [HttpGet("sku/{sku}")]
        public async Task<Disc> GetDiscBySKU(int sku)
        {
            return await db.Discs.FirstOrDefaultAsync(d => d.SKU == sku);
        }
    }
}