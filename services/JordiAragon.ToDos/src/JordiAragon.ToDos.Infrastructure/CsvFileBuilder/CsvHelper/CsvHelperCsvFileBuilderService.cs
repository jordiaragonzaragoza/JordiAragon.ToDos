namespace JordiAragon.ToDos.Infrastructure.CsvFileBuilder.CsvHelper
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using global::CsvHelper;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragon.ToDos.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Infrastructure.CsvFileBuilder.CsvHelper.Maps;

    public class CsvHelperCsvFileBuilderService : ICsvFileBuilderService
    {
        public byte[] BuildTodoItemsFile(IEnumerable<ToDoItemOutputDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Context.RegisterClassMap<ToDoItemBasicOutputDtoMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}