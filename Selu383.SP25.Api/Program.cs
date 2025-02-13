using Microsoft.EntityFrameworkCore;

namespace Selu383.SP25.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();

                // Ensure database is created with latest schema
                await db.Database.EnsureCreatedAsync();

                // If no theaters exist, add the seed data
                if (!await db.Theaters.AnyAsync())
                {
                    // Remove explicit IDs and let SQL Server generate them
                    var theaters = new[]
                    {
                        new Models.Theater
                        {
                            Name = "AMC Hammond Square 8",
                            Address = "1200 W University Ave, Hammond, LA 70401",
                            SeatCount = 1200
                        },
                        new Models.Theater
                        {
                            Name = "Grand Cinema Slidell",
                            Address = "1950 Gause Blvd W, Slidell, LA 70460",
                            SeatCount = 800
                        },
                        new Models.Theater
                        {
                            Name = "Movie Tavern Covington",
                            Address = "201 N US Highway 190, Covington, LA 70433",
                            SeatCount = 950
                        }
                    };

                    await db.Theaters.AddRangeAsync(theaters);
                    await db.SaveChangesAsync();
                }
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}