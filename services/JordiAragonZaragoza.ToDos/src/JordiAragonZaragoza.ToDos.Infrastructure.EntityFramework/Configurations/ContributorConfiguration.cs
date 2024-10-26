namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework.Configurations
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework.Configuration;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContributorConfiguration : BaseEntityTypeConfiguration<Contributor, ContributorId>
    {
        public override void Configure(EntityTypeBuilder<Contributor> builder)
        {
            base.Configure(builder);

            builder.Property(contributor => contributor.Id)
                .HasConversion(
                    contributorId => contributorId.Value,
                    value => ContributorId.Create(value))
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(contributor => contributor.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}