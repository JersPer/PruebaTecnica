using PruebaMedismart.Application.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/<UsersController>/5
    [HttpGet("{id:int:min(1)}")]
    public Task<UserDto> Get(int id)
    {
        return _mediator.Send(new GetUserByIdQuery(id));
    }
}
