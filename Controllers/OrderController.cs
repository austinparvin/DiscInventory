using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscInventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DiscInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public DatabaseContext db { get; set; } = new DatabaseContext();
        [HttpGet]
        public async Task<List<Order>> GetAllOrders()
        {
            return await db.Orders.OrderBy(o => o.PlacedAt).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(List<Disc> Discs)
        {
            // create order and add it to database/save changes
            var orderToAdd = new Order();
            await db.Orders.AddAsync(orderToAdd);
            await db.SaveChangesAsync();

            // initialize an empty List<DiscOrder>
            var discOrdersToAdd = new List<DiscOrder>();
            // foreach disc passed in create a DicsOrder Entry with the current order Id
            foreach (Disc d in Discs)
            {
                var discOrderToAdd = new DiscOrder();
                discOrderToAdd.OrderId = orderToAdd.Id;
                discOrderToAdd.DiscId = d.Id;
                //Save DiscOrder to db
                db.DiscOrders.Add(discOrderToAdd);
                await db.SaveChangesAsync();
                // add new DiscOrder entry to List<DiscOrder>
                discOrdersToAdd.Add(discOrderToAdd);

            }
            // set order.DiscOrders = to the List<DiscOrder> that we just made above
            orderToAdd.DiscOrders = discOrdersToAdd;
            // db.SaveChanges();
            await db.SaveChangesAsync();
            //return order
            return new ContentResult()
            {
                Content = JsonConvert.SerializeObject(orderToAdd,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }),
                ContentType = "application/json",
                StatusCode = 200
            };
        }
        //how to make a post request to create an order that contains many-to-many related items
    }
}