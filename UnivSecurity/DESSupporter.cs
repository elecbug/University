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
            byte[] bytes = Encoding.Unicode.GetBytes(str);
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

        public static string ToString(List<BitArray> bits)
        {
            string result = string.Empty;

            for (int i = 0; i <  bits.Count; i++) 
            {
                result += Encoding.Unicode.GetString(ToByteArray(bits[i]));
            }

            return result;
        }

        private static byte[] ToByteArray(BitArray bits)
        {
            int num_bytes = bits.Count / 8;
            if (bits.Count % 8 != 0)
            {
                num_bytes++;
            }
            byte[] bytes = new byte[num_bytes];
            int byte_idx = 0, bit_idx = 8;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                {
                    bytes[byte_idx] |= (byte)(0b1000_0000 >> (bit_idx - 1));
                }
                bit_idx--;

                if (bit_idx == 0)
                {
                    bit_idx = 8;
                    byte_idx++;
                }
            }

            return bytes;
        }
    }
}
