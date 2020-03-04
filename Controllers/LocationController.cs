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
    public class LocationController : ControllerBase
    {
        public DatabaseContext db { get; set; } = new DatabaseContext();

        //  A POST endpoint that allows a user to create a location
        [HttpPost]
        public async Task<Location> CreateLocation(Location locationToAdd)
        {
            await db.Locations.AddAsync(locationToAdd);
            await db.SaveChangesAsync();
            return locationToAdd;
        }

        //  A GET endpoint that gets all locations
        [HttpGet]
        public async Task<List<Location>> GetAllLocations()
        {
            return await db.Locations.OrderBy(l => l.Address).ToListAsync();

        }
    }
}