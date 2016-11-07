using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TestApi.PrototypeApi;
using TestApi.Models;

namespace TestApi {
  public class Startup {
    public void ConfigureServices(IServiceCollection services) {
      services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
      loggerFactory.AddConsole(LogLevel.Debug);

      var api = app.ApplicationServices.GetService<ApiContext>();
      AddTestData(api); 

      app.UseMvc(routes => {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}"
        );
      });
    }

    private static void AddTestData(ApiContext api) {
      var testUser1 = new User {
        id = 1,
        firstName = "Luke",
        lastName = "Skywalker"
      };
      var testUser2 = new User {
        id = 2,
        firstName = "Han",
        lastName = "Solo"
      };
 
      api.Users.Add(testUser1);
      api.Users.Add(testUser2);
      api.SaveChanges();
    }
  }
}