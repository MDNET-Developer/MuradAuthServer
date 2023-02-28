using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.DTOs
{
    public class TokenDto
    {
        public string AccsessToken { get; set; }
        public DateTime AccsessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
