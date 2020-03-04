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

        [HttpGet]
        public async Task<List<Disc>> GetAllDiscs()
        {
            return await db.Discs.OrderBy(d => d.Name).ToListAsync();
        }
        [HttpGet("id/{id}")]
        public async Task<Disc> GetDiscById(int id)
        {
            return await db.Discs.FirstOrDefaultAsync(d => d.Id == id);
        }
        [HttpPost]
        public async Task<Disc> AddDiscToInventory(Disc disc)
        {
            await db.Discs.AddAsync(disc);
            await db.SaveChangesAsync();
            return disc;
        }
        [HttpPut("{id}")]
        public async Task<Disc> UpdateDiscInInventory(int id, Disc newDiscData)
        {
            newDiscData.Id = id;
            db.Entry(newDiscData).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return newDiscData;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiscFromInventory(int id)
        {
            var discToRemove = await db.Discs.FirstOrDefaultAsync(d => d.Id == id);
            db.Discs.Remove(discToRemove);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("oos")]
        public async Task<List<Disc>> GetAllDiscsOutOfStock()
        {
            return await db.Discs.Where(d => d.NumberInStock == 0).ToListAsync();
        }
        [HttpGet("sku/{sku}")]
        public async Task<Disc> GetDiscBySKU(int sku)
        {
            return await db.Discs.FirstOrDefaultAsync(d => d.SKU == sku);
        }
    }
}