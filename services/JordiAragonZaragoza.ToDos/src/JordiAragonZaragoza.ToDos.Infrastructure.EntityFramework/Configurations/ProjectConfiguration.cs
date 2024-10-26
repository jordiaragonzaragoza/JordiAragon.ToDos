namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework.Configurations
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework.Configuration;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjectConfiguration : BaseEntityTypeConfiguration<Project, ProjectId>
    {
        public override void Configure(EntityTypeBuilder<Project> projectBuilder)
        {
            base.Configure(projectBuilder);

            projectBuilder.Property(project => project.Id)
                .HasConversion(
                    projectId => projectId.Value,
                    value => ProjectId.Create(value))
                .IsRequired()
                .ValueGeneratedNever();

            projectBuilder.Property(project => project.Name)
                .HasMaxLength(200)
                .IsRequired();

            projectBuilder.OwnsOne(project => project.Color, colorBuilder =>
            {
                colorBuilder.OwnsOne(color => color.R);
                colorBuilder.OwnsOne(color => color.G);
                colorBuilder.OwnsOne(color => color.B);
            }).Navigation(project => project.Color).IsRequired();
        }
    }
}