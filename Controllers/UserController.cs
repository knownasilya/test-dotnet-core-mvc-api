using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestApi.PrototypeApi;

namespace Test.Controllers {
  [Route("api/[controller]")]
  public class UsersController : Controller {
    private readonly ApiContext db;
    public UsersController(ApiContext context) {
      db = context;
    }

    // GET: api/users/ or /api/users/123
    [HttpGet]
    [HttpGet("{id}")]
    public async Task<Object> Get(int id = 0) {
      if (id > 0) {
        var user = await db.Users.SingleAsync(u => u.id == id);
        return new { user };
      } else {
        var users = await db.Users.ToArrayAsync();
        return new { users };
      }
    }
  }
}