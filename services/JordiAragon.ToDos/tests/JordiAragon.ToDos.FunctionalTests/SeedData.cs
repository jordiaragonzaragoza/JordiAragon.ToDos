namespace JordiAragon.ToDos.FunctionalTests
{
    using System;
    using JordiAragon.ToDos.Domain.AccountAggregate;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels;
    using JordiAragon.ToDos.Infrastructure.EntityFramework;

    public static class SeedData
    {
        public static readonly Account Account1 = Account.Create(AccountId.Create(Guid.NewGuid()), "FirstnameTest", "LastnameTest", "test@test.com", "test@test.com");
        public static readonly Contributor Contributor1 = Contributor.Create(ContributorId.Create(Guid.NewGuid()), "John");
        public static readonly Contributor Contributor2 = Contributor.Create(ContributorId.Create(Guid.NewGuid()), "Susan");
        public static readonly Project TestProject1 = Project.Create(ProjectId.Create(Guid.NewGuid()), "Test Project", Priority.None, Color.White);

        public static readonly ToDoItem ToDoItem1 = ToDoItem.Create(ToDoItemId.Create(Guid.NewGuid()), TestProject1.Id, "Get Sample Working", "Try to get the sample to build.", Priority.None);
        public static readonly ToDoItem ToDoItem2 = ToDoItem.Create(ToDoItemId.Create(Guid.NewGuid()), TestProject1.Id, "Review Solution", "Review the different projects in the solution and how they relate to one another.", Priority.None);
        public static readonly ToDoItem ToDoItem3 = ToDoItem.Create(ToDoItemId.Create(Guid.NewGuid()), TestProject1.Id, "Run and Review Tests", "Make sure all the tests run and review what they are doing.", Priority.None);

        public static void PopulateTestData(ToDosContext dbContext)
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