using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PKI.CA
{
    public class Process : BaseProcess
    {
        private RSA UsingCA { get; set; }

        public Process(RSA usingCA) : base(0, new TcpClient())
        {
            UsingCA = usingCA;
        }
    }
}
