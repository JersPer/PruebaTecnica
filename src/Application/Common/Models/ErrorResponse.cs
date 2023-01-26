using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Models;
public class ErrorResponse
{
    public string ErrorCode { get; init; }
    public string ErrorMessage { get; init; }
}
