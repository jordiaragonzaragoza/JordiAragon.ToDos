namespace JordiAragon.ToDos.Infrastructure.CsvFileBuilder.CsvHelper.Maps
{
    using System.Globalization;
    using global::CsvHelper.Configuration;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public class ToDoItemBasicOutputDtoMap : ClassMap<ToDoItemOutputDto>
    {
        public ToDoItemBasicOutputDtoMap()
        {
            this.AutoMap(CultureInfo.InvariantCulture);
        }
    }
}