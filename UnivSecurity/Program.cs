using System.Collections;

namespace UnivSecurity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine()!;
            switch (command.Split(' ')[1].ToUpper())
            {
                case "-E":
                    {
                        string file = command.Split(' ')[0];

                        StreamReader reader = new StreamReader(file);
                        List<BitArray> input = DESSupporter.To64Bits(reader.ReadToEnd());

                        List<DES> des1 = new List<DES>();
                        List<BitArray> output = new List<BitArray>();

                        des1.Add(new DES()
                        {
                            Input = DESSupporter.To64Bits(reader.BaseStream.Length)[0],
                            Key = new BitArray(56, true),
                        });
                        des1[0].Encrypt();
                        output.Add(des1[0].Output);

                        for (int i = 0; i < input.Count; i++)
                        {
                            des1.Add(new DES()
                            {
                                Input = input[i],
                                Key = new BitArray(56, true),
                            });

                            des1[i + 1].Encrypt();
                            output.Add(des1[i + 1].Output);

                            //Console.WriteLine("Cipher Text");
                            //for (int j = 0; j < 64; j++)
                            //{
                            //    Console.Write(output[i][j] ? "1 " : "0 ");
                            //}
                            //Console.WriteLine();
                        }

                        StreamWriter ewriter = new StreamWriter("e-" + file);
                        ewriter.Write(DESSupporter.ToString(output));

                        reader.Close();
                        ewriter.Close();
                    }
                    break;
                case "-D":
                    {
                        string file = command.Split(' ')[0];

                        StreamReader ereader = new StreamReader(file);
                        List<BitArray> encrytion = DESSupporter.To64Bits(ereader.ReadToEnd());

                        List<DES> des2 = new List<DES>();
                        List<BitArray> rebirth = new List<BitArray>();

                        DES blocks = new DES()
                        {
                            Input = encrytion[0],
                            Key = new BitArray(56, true),
                        };
                        blocks.Decrypt();

                        long size = BitConverter.ToInt64(DESSupporter.ToByteArray(blocks.Output), 0);

                        for (int i = 1; i < encrytion.Count; i++)
                        {
                            des2.Add(new DES()
                            {
                                Input = encrytion[i],
                                Key = new BitArray(56, true),
                            });

                            des2[i - 1].Decrypt();
                            rebirth.Add(des2[i - 1].Output);

                            //Console.WriteLine("Rebirth Text: ");
                            //for (int j = 0; j < 64; j++)
                            //{
                            //    Console.Write(rebirth[i][j] ? "1 " : "0 ");
                            //}
                            //Console.WriteLine();
                        }

                        StreamWriter rewriter = new StreamWriter("re-" + file);
                        string str = DESSupporter.ToString(rebirth).Substring(0, (int)size);
                        rewriter.Write(str);

                        Console.WriteLine(str);

                        ereader.Close();
                        rewriter.Close();
                    }
                    break;
            }
        }
    }
}