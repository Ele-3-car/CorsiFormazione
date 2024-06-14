using CorsiFormazione.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Application.Abstractions.Services
{
    public interface ITokenService
    {
        string CreateToken(CreateTokenRequest request);
    }
}
