using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.DTOs
{
    public class ClientLogInDto
    {
        public int ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
