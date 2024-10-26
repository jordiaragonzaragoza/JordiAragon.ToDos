namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework.Configurations
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework.Configuration;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ToDoItemConfiguration : BaseEntityTypeConfiguration<ToDoItem, ToDoItemId>
    {
        public override void Configure(EntityTypeBuilder<ToDoItem> toDoItemBuilder)
        {
            base.Configure(toDoItemBuilder);

            toDoItemBuilder.Property(toDoItem => toDoItem.Id)
                .HasConversion(
                    toDoItemId => toDoItemId.Value,
                    value => ToDoItemId.Create(value))
                .IsRequired()
                .ValueGeneratedNever();

            toDoItemBuilder.Property(toDoItem => toDoItem.Title)
                .HasMaxLength(200)
                .IsRequired();

            toDoItemBuilder.HasOne<Contributor>()
                .WithMany()
                .HasForeignKey(toDoItem => toDoItem.ContributorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull); // Will be deleted using application events.

            toDoItemBuilder.HasOne<Project>()
                .WithMany(project => project.Items)
                .HasForeignKey(toDoItem => toDoItem.ProjectId)
                .IsRequired();

            toDoItemBuilder.OwnsOne(t => t.Location, locationBuilder =>
            {
                locationBuilder.OwnsOne(location => location.Coordinates, coordinatesBuilder =>
                {
                    coordinatesBuilder.OwnsOne(coordinate => coordinate.Latitude);
                    coordinatesBuilder.OwnsOne(coordinate => coordinate.Longitude);
                }).Navigation(location => location.Coordinates).IsRequired();
            }).Navigation(t => t.Location).IsRequired();
        }
    }
}