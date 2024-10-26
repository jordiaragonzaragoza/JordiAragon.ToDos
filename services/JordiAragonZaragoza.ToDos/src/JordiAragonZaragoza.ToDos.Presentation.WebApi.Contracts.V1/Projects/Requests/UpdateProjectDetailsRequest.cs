namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.Requests
{
    using System;

    public record class UpdateProjectDetailsRequest(
        string Name,
        PriorityRequest Priority,
        ColorRequest Color);
}