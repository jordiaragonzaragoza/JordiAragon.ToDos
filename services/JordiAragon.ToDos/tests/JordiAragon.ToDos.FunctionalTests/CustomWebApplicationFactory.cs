namespace JordiAragon.ToDos.FunctionalTests
{
    using System;
    using JordiAragon.SharedKernel.Helpers;
    using JordiAragon.ToDos.Infrastructure.EntityFramework;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
        where TProgram : class
    {
        /// <summary>
        /// Overriding CreateHost to avoid creating a separate ServiceProvider per
        /// <see href="https://github.com/dotnet-architecture/eShopOnWeb/issues/465">this thread</see>.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>A host intance.</returns>
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Development"); // will not send real emails
            var host = builder.Build();
            host.Start();

            // Get service provider.
            var serviceProvider = host.Services;

            // Create a scope to obtain a reference to the database
            // context (ToDosContext).
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ToDosContext>();

                var logger = scopedServices
                    .GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

                // Ensure the database is created.
                db.Database.EnsureCreated();

                try
                {
                    // Can also skip creating the items
                    ////if (!db.ToDoItems.Any())
                    ////{
                    //// Seed the database with test data.
                    SeedData.PopulateTestData(db);
                    ////}
                }
                catch (Exception ex)
                {
                    logger.LogError(
                        ex,
                        "An error occurred seeding the " + "database with test messages. Error: {exceptionMessage}",
                        ex.Message);
                }
            }

            return host;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    // This should be set for each individual test run
                    string inMemoryCollectionName = Guid.NewGuid().ToString();

                    // Add ApplicationDbContext using an in-memory database for testing.
                    services
                    .Remove<DbContextOptions<ToDosContext>>()
                    .AddDbContext<ToDosContext>((sp, options) =>
                        options.UseInMemoryDatabase(inMemoryCollectionName)
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
                });
        }
    }
}