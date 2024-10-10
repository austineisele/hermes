using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Infrastructure
{
    public static class Constants
    {
        /// <summary>
        /// Standard port app will access
        /// </summary>
        public static int PORT = 4789;
        
        /// <summary>
        /// Testing port. Local loopback.
        /// </summary>
        public static IPAddress TestAddress = IPAddress.Loopback;

        /// <summary>
        /// Production port. Can be any.
        /// </summary>
        public static IPAddress ProdAddress = IPAddress.Any;

    }
}
