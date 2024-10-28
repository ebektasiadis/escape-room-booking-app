using Escape.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escape.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.FirstName).HasConversion(firstName => firstName.Value, value => new FirstName(value));
        builder.Property(u => u.LastName).HasConversion(firstName => firstName.Value, value => new LastName(value));
        builder.Property(u => u.Email).HasConversion(email => email.Value, value => new Email(value));
        builder.Property(u => u.BirthDate).HasConversion(birthDate => birthDate.Value, value => new BirthDate(value));
    }
}
