using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKI
{
    public class Command
    {
        public const string GetKey = "get-key";

        public static string Create(int sendId, int recvId, string msg) 
            => sendId + "," + recvId + "," + msg;
        public static string[] Split(string str)
            => str.Split(',');
    }
}
