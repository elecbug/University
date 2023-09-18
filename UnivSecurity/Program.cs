using System.Collections;

namespace UnivSecurity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BitArray> input = BitArrayManager.To64Bits(Console.ReadLine()!);
            List<DES> des1 = new List<DES>();
            List<BitArray> output = new List<BitArray>();

            for (int i = 0; i < input.Count; i++)
            {
                des1.Add(new DES()
                {
                    Input = input[i],
                    Key = new BitArray(56, true),
                });

                des1[i].Encrypt();
                output.Add(des1[i].Output);

                Console.WriteLine("Cipher Text");
                for (int j = 0; j < 64; j++)
                {
                    Console.Write(output[i][j] ? "1 " : "0 ");
                }
                Console.WriteLine();
            }

            List<DES> des2 = new List<DES>();
            List<BitArray> rebirth = new List<BitArray>();

            for (int i = 0; i < output.Count; i++)
            {
                des2.Add(new DES()
                {
                    Input = output[i],
                    Key = new BitArray(56, true),
                });

                des2[i].Decrypt();
                rebirth.Add(des2[i].Output);

                Console.WriteLine("Rebirth Text: ");
                for (int j = 0; j < 64; j++)
                {
                    Console.Write(rebirth[i][j] ? "1 " : "0 ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(BitArrayManager.ToString(rebirth));
        }
    }
}