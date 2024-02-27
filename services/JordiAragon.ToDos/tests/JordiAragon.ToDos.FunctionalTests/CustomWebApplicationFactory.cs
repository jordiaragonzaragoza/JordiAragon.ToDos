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
            builder.UseEnvironment("Development");
            var host = builder.Build();
            host.Start();

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