using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UnivSecurity
{
    public class DESSupporter
    {
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

        public static byte[] ToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
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
    }
}
