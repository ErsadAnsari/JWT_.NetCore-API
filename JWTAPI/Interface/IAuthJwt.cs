using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAPI.Interface
{
    public interface IAuthJwt
    {
        string Authentication(string UserId, string Password);
    }
}
