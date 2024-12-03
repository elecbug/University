using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UnivSecurity
{
    /// <summary>
    /// DES 사용을 위한 bit 간의 전환을 돕는 컨버터 
    /// </summary>
    public class DESSupporter
    {
        /// <summary>
        /// 문자열을 64 bit 단위로 끊어 리스트로 반환
        /// </summary>
        /// <param name="str"> 입력 문자열 </param>
        /// <returns> 64 bit 단위로 끊어진 리스트 </returns>
        public static List<BitArray> To64Bits(string str)
        {
            byte[] bytes = Encoding.BigEndianUnicode.GetBytes(str);
            List<byte> list = bytes.ToList(); 

            while (list.Count % 8 != 0)
            {
                list.Add(0);
            }

            List<BitArray> result = new List<BitArray>();

            for (int i = 0; i < bytes.Length / 8 + (bytes.Length % 8 > 0 ? 1 : 0); i++)
            {
                result.Add(new BitArray(list.GetRange(i * 8, 8).ToArray()));
            }

            return result;
        }
        /// <summary>
        /// Int64를 64 bit 단위로 끊어 리스트로 반환
        /// </summary>
        /// <param name="ln"> 입력 long 변수 </param>
        /// <returns> 64 bit 단위로 끊어진 리스트 </returns>
        public static List<BitArray> To64Bits(long ln)
        {
            byte[] bytes = BitConverter.GetBytes(ln);
            List<byte> list = bytes.ToList();

            while (list.Count % 8 != 0)
            {
                list.Add(0);
            }

            List<BitArray> result = new List<BitArray>();

            for (int i = 0; i < bytes.Length / 8 + (bytes.Length % 8 > 0 ? 1 : 0); i++)
            {
                result.Add(new BitArray(list.GetRange(i * 8, 8).ToArray()));
            }

            return result;
        }
        /// <summary>
        /// 하나의 BitArray를 64 bit 단위로 끊어 리스트로 반환
        /// </summary>
        /// <param name="ln"> 입력 단일 BitArray </param>
        /// <returns> 64 bit 단위로 끊어진 리스트 </returns>
        public static List<BitArray> To64Bits(BitArray bits)
        {
            int count = bits.Count / 64 + (bits.Count % 64 > 1 ? 1 : 0 );

            List<BitArray> list = new List<BitArray>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new BitArray(64));
                
                for (int j = 0; j < 64; j++)
                {
                    if (i * 64 + j >= bits.Count)
                    {
                        break;
                    }

                    list[i][j] = bits[i * 64 + j];
                }
            }

            return list;
        }

        /// <summary>
        /// BitArray 리스트를 문자열로 바꾸어 반환
        /// </summary>
        /// <param name="bits"> 입력 리스트 </param>
        /// <returns> 합친 후 변환된 문자열 </returns>
        public static string ToString(List<BitArray> bits)
        {
            BitArray sum = new BitArray(bits.Count * 64);

            for (int i = 0; i < bits.Count; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    sum[i * 64 + j] = bits[i][j];
                }
            }

            string result = Encoding.BigEndianUnicode.GetString(ToByteArray(sum));
            return result;
        }

        /// <summary>
        /// BitArray를 8 bit씩 끊어 Byte 배열로 반환
        /// </summary>
        /// <param name="bits"> 입력 단일 BitArray </param>
        /// <returns> 8 bit씩 묶어 Byte로 변환된 배열 </returns>
        public static byte[] ToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        /// <summary>
        /// 64 bit 구조의 BitArray 리스트를 8개씩 묶어 8n Byte 배열로 반환
        /// </summary>
        /// <param name="bits"> 입력 BitArray 리스트(한 원소는 64 bit) </param>
        /// <returns> 8n개의 Byte로 변환된 배열 </returns>
        public static byte[] ToByteArray(List<BitArray> list)
        {
            BitArray bits = new BitArray(list.Count * 64);

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    bits[i * 64 + j] = list[i][j];
                }
            }

            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        /// <summary>
        /// 16진수 문자열을 Byte 배열로 반환
        /// </summary>
        /// <param name="hex"> 16진수로 표기된 문자열 </param>
        /// <returns> 변환된 Byte 배열 </returns>
        public static byte[] HexToByte(string hex)
        {
            byte[] convert = new byte[hex.Length / 2];

            int length = convert.Length;
            for (int i = 0; i < length; i++)
            {
                convert[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return convert;
        }
    }
}
