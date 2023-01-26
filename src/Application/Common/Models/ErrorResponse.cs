using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace PruebaMedismart.Application.Common.Models;

[SwaggerSchema("Error Response")]
public class ErrorResponse
{
    public string ErrorCode { get; init; }
    public string ErrorMessage { get; init; }
}
