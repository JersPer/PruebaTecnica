using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMedismart.Application.Users.Queries.GetUser;
public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MotherLastName { get; set; }
    public string FatherLastName { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
}
