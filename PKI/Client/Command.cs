using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PKI.Client
{
    /// <summary>
    /// 커맨드 모음 클래스
    /// </summary>
    public class Command
    {
        public const string GenerateKey = ";gen-key";
        public const string RecvGenKey = "recv-gen-key";
        public const string Cancel = "cancel";
        public const string GetKey = ";get-key";
        public const string RecvGetKey = "recv-get-key";
        public const string SendMsg = ";send";
        public const string RecvMsg = "recv-send";
        public const string OnlyAccept = ";only-y";

        /// <summary>
        /// 각 키워드 사이의 구분자
        /// </summary>
        public const string Splitter = "[SPL ]";

        /// <summary>
        /// 패킷 생성 메서드
        /// </summary>
        /// <param name="sendId"> 작성자의 아이디 </param>
        /// <param name="recvId"> 수신자의 아이디 </param>
        /// <param name="command"> 주요 커맨드 </param>
        /// <param name="value"> 커맨드의 추가 내용 </param>
        /// <param name="sign"> 작성자의 싸인 </param>
        /// <returns> 완성된 패킷 커맨드 </returns>
        public static string Create(int sendId, int recvId, string command, string value = "", string sign = "")
            => sendId + Splitter + recvId + Splitter + command + Splitter + value + Splitter + sign;
        public static string[] Split(string str)
            => str.Split(Splitter);

        /// <summary>
        /// 헥사 스트링 생성 메서드
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }

        /// <summary>
        /// 헥사 스트링을 바이트로 변경
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
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
