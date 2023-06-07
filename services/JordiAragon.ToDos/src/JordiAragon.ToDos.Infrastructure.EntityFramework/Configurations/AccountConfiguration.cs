namespace JordiAragon.ToDos.Infrastructure.EntityFramework.Configurations
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework.Configuration;
    using JordiAragon.ToDos.Domain.AccountAggregate;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AccountConfiguration : BaseEntityTypeConfiguration<Account, AccountId>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.Property(account => account.Id)
                .HasConversion(
                    accountId => accountId.Value,
                    value => AccountId.Create(value))
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(account => account.Firstname)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(account => account.Lastname)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(account => account.Email)
                .HasMaxLength(320)
                .IsRequired();

            builder.HasIndex(account => account.Email)
                .IsUnique();

            builder.Property(account => account.Password)
                .IsRequired();
        }
    }
}