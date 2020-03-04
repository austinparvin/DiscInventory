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
    }
}