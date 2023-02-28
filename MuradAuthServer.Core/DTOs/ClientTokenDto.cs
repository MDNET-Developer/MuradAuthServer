using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.DTOs
{
    public class ClientTokenDto
    {
        public string AccsessToken { get; set; }
        public DateTime AccsessTokenExpiration { get; set; }
    }
}
