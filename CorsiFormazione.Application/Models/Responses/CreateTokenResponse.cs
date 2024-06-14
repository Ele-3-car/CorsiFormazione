using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Application.Models.Responses
{
    public class CreateTokenResponse
    {
        public string Token { get; set; } = string.Empty;

        public CreateTokenResponse(string token)
        {
            Token = token;
        }
    }
}
