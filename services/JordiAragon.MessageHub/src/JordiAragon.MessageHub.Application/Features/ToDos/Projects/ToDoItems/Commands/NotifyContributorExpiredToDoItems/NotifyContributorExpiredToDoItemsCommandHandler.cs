namespace JordiAragon.MessageHub.Application.Features.ToDos.Projects.ToDoItems.Commands.NotifyContributorExpiredToDoItems
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.MessageHub.Application.Contracts.Features.ToDos.Projects.ToDoItems.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using Microsoft.Extensions.Logging;

    public class NotifyContributorExpiredToDoItemsCommandHandler : ICommandHandler<NotifyContributorExpiredToDoItemsCommand>
    {
        private readonly ILogger<NotifyContributorExpiredToDoItemsCommandHandler> logger;

        public NotifyContributorExpiredToDoItemsCommandHandler(
            ILogger<NotifyContributorExpiredToDoItemsCommandHandler> logger)
        {
            this.logger = logger;
        }

        public async Task<Result> Handle(NotifyContributorExpiredToDoItemsCommand request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Command Executed: {Command}: {@Message}", nameof(NotifyContributorExpiredToDoItemsCommand), request);

            // TODO: Complete implementation.
            return await Task.FromResult(Result.Success());
        }
    }
}