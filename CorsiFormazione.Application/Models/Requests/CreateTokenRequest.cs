using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Application.Models.Requests
{
    public class CreateTokenRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
