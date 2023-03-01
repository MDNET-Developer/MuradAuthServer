using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.DTOs
{
    public class CreateUserDto
    {
        public int UserName { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }
    }
}
