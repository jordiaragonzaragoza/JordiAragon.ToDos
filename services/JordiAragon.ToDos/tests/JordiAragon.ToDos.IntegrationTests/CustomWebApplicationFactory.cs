﻿namespace JordiAragon.ToDos.IntegrationTests
{
    using JordiAragon.SharedKernel.Helpers;
    using JordiAragon.ToDos.Infrastructure.EntityFramework;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configurationBuilder =>
            {
                var integrationConfig = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Tests.json")
                    .AddEnvironmentVariables()
                    .Build();

                configurationBuilder.AddConfiguration(integrationConfig);
            });

            builder.ConfigureServices((builder, services) =>
            {
                /*
                services
                    .Remove<ICurrentUserService>()
                    .AddTransient(provider => Mock.Of<ICurrentUserService>(s =>
                        s.UserId == GetCurrentUserId()));
                */

                services
                    .Remove<DbContextOptions<ToDosContext>>()
                    .AddDbContext<ToDosContext>((sp, options) =>
                        options.UseSqlServer(
                            builder.Configuration.GetConnectionString("ToDosConnection"),
                            builder => builder.MigrationsAssembly(typeof(ToDosContext).Assembly.FullName)));
            });
        }
    }
}