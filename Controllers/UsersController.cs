using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TestApi.PrototypeApi;

namespace TestApi.Controllers {
  [Route("api/[controller]")]
  public class UsersController : Controller {
    private readonly ApiContext db;
    private readonly ILogger<UsersController> logger;
    public UsersController(ApiContext context, ILogger<UsersController> lgr) {
      db = context;
      logger = lgr;
    }

    [HttpGet]
    public async Task<Object> GetAll() {
      logger.LogInformation("Fetching all users");

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