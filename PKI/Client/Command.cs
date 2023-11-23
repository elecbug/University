using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PKI.Client
{
    public class Command
    {
        public const string GenerateKey = "gen-key";
        public const string RecvKey = "recv-key";
        public const string Cancel = "cancel";
        public const string GetKey = "get-key";
        public const string RecvGetKey = "recv-get-key";
        public const string SendMsg = "send-msg";
        public const string RecvMsg = "recv-msg";
        public static readonly byte[] Sign = Encoding.UTF8.GetBytes("This is sign text :)");
        public const string Splitter = "adfhkl;dfskdsfkhj;dfshkjl";

        public static string Create(int sendId, int recvId, string command, string value = "", string sign = "")
            => sendId + Splitter + recvId + Splitter + command + Splitter + value + Splitter + sign;
        public static string[] Split(string str)
            => str.Split(Splitter);

        public static string ByteArrayToString(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.TrimEnd('\0');
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
