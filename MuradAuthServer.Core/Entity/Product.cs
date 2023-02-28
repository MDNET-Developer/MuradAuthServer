using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.Entity
{
    public  class Product
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public Decimal Price  { get; set; }
        public int Stock { get; set; }
        public string UserId { get; set; }/*Identity-de UserId string olaraq yadda saxlanilir*/
    }
}
