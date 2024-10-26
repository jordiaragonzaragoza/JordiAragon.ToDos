namespace JordiAragonZaragoza.ToDos.IntegrationTests
{
    using System.Threading.Tasks;
    using JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework;
    using MediatR;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Respawn;
    using Xunit;

    public class TestingFixture : IAsyncLifetime
    {
        private WebApplicationFactory<Program> factory;
        private IConfiguration configuration;
        private IServiceScopeFactory scopeFactory;
        private Respawner checkpoint;
        ////private static string currentUserId;

        public async Task InitializeAsync()
        {
            this.factory = new CustomWebApplicationFactory();
            this.scopeFactory = this.factory.Services.GetRequiredService<IServiceScopeFactory>();
            this.configuration = this.factory.Services.GetRequiredService<IConfiguration>();

            this.checkpoint = await Respawner.CreateAsync(this.configuration.GetConnectionString("ToDosConnection"), new RespawnerOptions
            {
                TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" },
            });
        }

        /*
        public static string GetCurrentUserId()
        {
            return currentUserId;
        }

        public static async Task<string> RunAsDefaultUserAsync()
        {
            return await RunAsUserAsync("test@local", "Testing1234!", Array.Empty<string>());
        }

        public static async Task<string> RunAsAdministratorAsync()
        {
            return await RunAsUserAsync("administrator@local", "Administrator1234!", new[] { "Administrator" });
        }

        public static async Task<string> RunAsUserAsync(string userName, string password, string[] roles)
        {
            using var scope = scopeFactory.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser { UserName = userName, Email = userName };

            var result = await userManager.CreateAsync(user, password);

            if (roles.Any())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                await userManager.AddToRolesAsync(user, roles);
            }

            if (result.Succeeded)
            {
                currentUserId = user.Id;

                return currentUserId;
            }

            var errors = string.Join(Environment.NewLine, result.ToApplicationResult().Errors);

            throw new Exception($"Unable to create {userName}.{Environment.NewLine}{errors}");
        }
        */

        public Task DisposeAsync()
        {
            // No es necesario hacer nada aquí, ya que la limpieza se realiza en InitializeAsync
            return Task.CompletedTask;
            ////currentUserId = null;
        }

        public async Task ResetState()
        {
            await this.checkpoint.ResetAsync(this.configuration.GetConnectionString("ToDosConnection"));
        }

        public async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
            where TEntity : class
        {
            using var scope = this.scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ToDosContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = this.scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ToDosContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public async Task<int> CountAsync<TEntity>()
            where TEntity : class
        {
            using var scope = this.scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ToDosContext>();

            return await context.Set<TEntity>().CountAsync();
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = this.scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            return await mediator.Send(request);
        }
    }
}