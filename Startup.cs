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
      var context = app.ApplicationServices.GetService<ApiContext>();
      AddTestData(context); 

      app.UseMvc(routes => {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}"
        );
      });
    }

    private static void AddTestData(ApiContext context) {
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
 
      context.Users.Add(testUser1);
      context.Users.Add(testUser2);
      context.SaveChanges();
    }
  }
}