using PruebaMedismart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PruebaMedismart.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users{ get; }
}
