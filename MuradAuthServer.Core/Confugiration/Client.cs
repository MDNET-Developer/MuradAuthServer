using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.Confugiration
{
    public  class Client
    {
        public int Id { get; set; }
        public string Secret { get; set; } /*Uygulama sisteme kayıt edildikten sonra, sunucunun her uygulama için özel olarak vermiş olduğu secret değeridir*/

        public List<String> Audiences { get; set; } //Gondereceyim Token menim apilerimden hansina verilecek onu teyin edecem
    }
}
