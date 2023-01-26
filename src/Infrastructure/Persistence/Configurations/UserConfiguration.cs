using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PruebaMedismart.Domain.Entities;

namespace PruebaMedismart.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(t => t.Id)
            .IsRequired();
        builder.Property(t => t.Address)
            .IsRequired();
        builder.Property(t => t.FirstName)
            .IsRequired();
        builder.Property(t => t.LastName)
            .IsRequired();
        builder.Property(t => t.BirthDate)
            .IsRequired();
    }
}
