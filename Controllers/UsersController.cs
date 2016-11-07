using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestApi.PrototypeApi;

namespace TestApi.Controllers {
  [Route("api/[controller]")]
  public class UsersController : Controller {
    private readonly ApiContext db;
    public UsersController(ApiContext context) {
      db = context;
    }

    [HttpGet]
    public async Task<Object> GetAll() {
      var users = await db.Users.ToArrayAsync();
      return new { users };
    }

    // GET: api/users/ or /api/users/123
    [HttpGet("{id:int}")]
    public async Task<Object> GetById(int id = 0) {
      var user = await db.Users.SingleAsync(u => u.id == id);
      return new { user };
    }
  }
}