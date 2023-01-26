using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaMedismart.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaMedismart.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace PruebaMedismart.Application.Users.Queries.GetUser;

public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IApplicationDbContext _context;

    public GetUserByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
                    .Where(user => user.Id == request.Id)
                    .Select(user =>
                        new UserDto()
                        {
                            Id = user.Id,
                            Address = user.Address,
                            BirthDate = user.BirthDate,
                            FirstName = user.FirstName,
                            LastName = user.LastName
                        }).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (user == null) throw new NotFoundException($"User with Id ({request.Id}) was not found.");

        return user;
    }
}
