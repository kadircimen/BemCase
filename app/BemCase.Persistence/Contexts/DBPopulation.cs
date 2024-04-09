using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BemCase.Persistence.Contexts;
public static class DBPopulation
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var srv = scope.ServiceProvider;
            var context = srv.GetRequiredService<BemCaseDbContext>();
            context.Database.Migrate();
        }
    }
}
