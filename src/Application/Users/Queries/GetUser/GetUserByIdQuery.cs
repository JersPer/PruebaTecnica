using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Users.Queries.GetUser;

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
        return await _context.Users
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
    }
}
