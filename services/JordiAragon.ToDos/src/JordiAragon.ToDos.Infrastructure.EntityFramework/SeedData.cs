namespace JordiAragon.ToDos.Infrastructure.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using JordiAragon.ToDos.Domain.AccountAggregate;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public static class SeedData
    {
        public static readonly Account Account1 = Account.Create(AccountId.Create(Guid.NewGuid()), "FirstnameTest", "LastnameTest", "test@test.com", "test@test.com");
        public static readonly Contributor Contributor1 = Contributor.Create(ContributorId.Create(Guid.NewGuid()), "John");
        public static readonly Contributor Contributor2 = Contributor.Create(ContributorId.Create(Guid.NewGuid()), "Susan");
        public static readonly Project TestProject1 = Project.Create(ProjectId.Create(Guid.NewGuid()), "Test Project", Priority.None, Color.White);

        public static readonly ToDoItem ToDoItem1 = ToDoItem.Create(ToDoItemId.Create(Guid.NewGuid()), TestProject1.Id, "Get Sample Working", "Try to get the sample to build.", Priority.None);
        public static readonly ToDoItem ToDoItem2 = ToDoItem.Create(ToDoItemId.Create(Guid.NewGuid()), TestProject1.Id, "Review Solution", "Review the different projects in the solution and how they relate to one another.", Priority.None);
        public static readonly ToDoItem ToDoItem3 = ToDoItem.Create(ToDoItemId.Create(Guid.NewGuid()), TestProject1.Id, "Run and Review Tests", "Make sure all the tests run and review what they are doing.", Priority.None);

        public static void Initialize(WebApplication app, bool isDevelopment)
        {
            using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ToDosContext>();

            try
            {
                PopulateTestData(dbContext, isDevelopment);
            }
            catch (Exception exception)
            {
                app.Logger.LogError(exception, "An error occurred seeding the database with test data. Error: {exceptionMessage}", exception.Message);
            }
        }

        private static void PopulateTestData(ToDosContext dbContext, bool isDevelopment)
        {
            MigrateAndEnsureSqlServerDatabase(dbContext);

            if (!isDevelopment || HasAnyData(dbContext))
            {
                return;
            }

            SetPreconfiguredData(dbContext);
        }

        private static void MigrateAndEnsureSqlServerDatabase(DbContext context)
        {
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();
            }
        }

        private static bool HasAnyData(DbContext context)
        {
            var dbSets = context.GetType().GetProperties()
                                           .Where(p => p.PropertyType.IsGenericType
                                                    && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var dbSetProperty in dbSets)
            {
                var dbSet = (IEnumerable<object>)dbSetProperty.GetValue(context);

                if (dbSet.Any())
                {
                    return true;
                }
            }

            return false;
        }

        private static void SetPreconfiguredData(ToDosContext dbContext)
        {
            foreach (var item in dbContext.Accounts)
            {
                dbContext.Remove(item);
            }

            foreach (var item in dbContext.Projects)
            {
                dbContext.Remove(item);
            }

            foreach (var item in dbContext.ToDoItems)
            {
                dbContext.Remove(item);
            }

            foreach (var item in dbContext.Contributors)
            {
                dbContext.Remove(item);
            }

            dbContext.SaveChanges();

            dbContext.Accounts.Add(Account1);

            dbContext.SaveChanges();

            dbContext.Contributors.Add(Contributor1);
            dbContext.Contributors.Add(Contributor2);

            dbContext.SaveChanges();

            ToDoItem1.AssignContributor(Contributor1.Id);
            ToDoItem2.AssignContributor(Contributor2.Id);
            ToDoItem3.AssignContributor(Contributor1.Id);

            dbContext.Projects.Add(TestProject1);

            dbContext.SaveChanges();
        }
    }
}