using MuradAuthServer.Core.Confugiration;
using MuradAuthServer.Core.DTOs;
using MuradAuthServer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.Service
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);
        ClientTokenDto CreateTokenByClient(Client client);/*Burdaki clienr menim AuthServerime istek atan applar olacaq. Bu mobil appda ola biler, web appda ola biler*/
    }
}
