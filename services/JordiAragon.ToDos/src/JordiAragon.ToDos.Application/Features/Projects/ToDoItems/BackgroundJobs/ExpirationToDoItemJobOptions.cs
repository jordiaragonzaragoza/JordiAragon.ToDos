namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.BackgroundJobs
{
    using System;

    public class ExpirationToDoItemJobOptions
    {
        public const string Section = "BackgroundJobs:ExpirationToDoItemJob";

        public int ScheduleIntervalInSeconds { get; set; }
    }
}