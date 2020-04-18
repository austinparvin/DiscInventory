# Objectives

- Create an API that can CRUD against a Database
- Reenforce SQL basics
- One to many relationships
- Working with Docker

# Includes: 

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [EF CORE](https://docs.microsoft.com/en-us/ef/core/)
- [POSTGRESQL](https://www.postgresql.org/)
- [CONTROLLERS](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller?view=aspnet-mvc-5.2)
- [POSTMAN](https://www.postman.com/)
- [DOCKER](https://www.docker.com/resources/what-container)
- [SWAGGER](https://swagger.io/solutions/api-documentation/)
- MVC design pattern

## Featured Code

### Using Action Results and Async

```C#
  [HttpGet]
  public async Task<ActionResult<List<Order>>> GetAllOrders()
  {
      var ordersToReturn = await db.Orders.OrderBy(o => o.PlacedAt).ToListAsync();

      foreach (Order order in ordersToReturn)
      {
          var oId = order.Id;
          order.DiscOrders = await db.DiscOrders.Where(o => o.OrderId == oId).ToListAsync();
      }

      return new ContentResult()
      {
          Content = JsonConvert.SerializeObject(ordersToReturn,
          new JsonSerializerSettings
          {
              ReferenceLoopHandling = ReferenceLoopHandling.Ignore
          }),
          ContentType = "application/json",
          StatusCode = 200
      };
  }
 ```
 
## User Actions

[API DOCUMENTATION](https://sdg-disc-inventory-api.herokuapp.com/index.html)
