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
        public const string RecvKey = "recv-key";
        public const string Cancel = "cancel";

        public static string Create(int sendId, int recvId, string command, string value = "") 
            => sendId + "," + recvId + "," + command + "," + value;
        public static string[] Split(string str)
            => str.Split(',');

        public static string Create(int id, int send, object command, string v)
        {
            throw new NotImplementedException();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
