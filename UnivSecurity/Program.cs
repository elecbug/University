﻿using System.Collections;
using System.Text;

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

                        //StreamReader reader = new StreamReader(file, encoding: Encoding.Default);
                        //string text = reader.ReadToEnd();
                        //List<BitArray> input = DESSupporter.To64Bits(text);

                        FileStream stream = File.OpenRead(file);
                        BinaryReader reader = new BinaryReader(stream);

                        byte[] bytes = reader.ReadBytes((int)stream.Length);
                        List<BitArray> input = DESSupporter.To64Bits(new BitArray(bytes));

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

                            //Console.WriteLine("Cipher Text");
                            //for (int j = 0; j < 64; j++)
                            //{
                            //    Console.Write(output[i][j] ? "1 " : "0 ");
                            //}
                            //Console.WriteLine();
                        }

                        //StreamWriter ewriter = new StreamWriter(command.Split(' ')[2], append: false, encoding: Encoding.Default);
                        //ewriter.Write(DESSupporter.ToString(output));

                        BinaryWriter writer = new BinaryWriter(File.Create(command.Split(' ')[2]));
                        writer.Write(DESSupporter.ToByteArray(output));

                        reader.Close();
                        writer.Close();
                    }
                    break;
                case "-D":
                    {
                        string file = command.Split(' ')[0];

                        //StreamReader ereader = new StreamReader(file, encoding: Encoding.Default);
                        //List<BitArray> encrytion = DESSupporter.To64Bits(ereader.ReadToEnd());

                        FileStream stream = File.OpenRead(file);
                        BinaryReader reader = new BinaryReader(stream);

                        byte[] bytes = reader.ReadBytes((int)stream.Length);
                        List<BitArray> encryption = DESSupporter.To64Bits(new BitArray(bytes));

                        List<DES> des2 = new List<DES>();
                        List<BitArray> rebirth = new List<BitArray>();

                        for (int i = 0; i < encryption.Count; i++)
                        {
                            des2.Add(new DES()
                            {
                                Input = encryption[i],
                                Key = new BitArray(56, true),
                            });

                            des2[i].Decrypt();
                            rebirth.Add(des2[i].Output);

                            //Console.WriteLine("Rebirth Text: ");
                            //for (int j = 0; j < 64; j++)
                            //{
                            //    Console.Write(rebirth[i][j] ? "1 " : "0 ");
                            //}
                            //Console.WriteLine();
                        }

                        //StreamWriter rewriter = new StreamWriter(command.Split(' ')[2], append: false, encoding: Encoding.Default);
                        //string str = DESSupporter.ToString(rebirth);
                        //rewriter.Write(str);

                        BinaryWriter writer = new BinaryWriter(File.Create(command.Split(' ')[2]));
                        writer.Write(DESSupporter.ToByteArray(rebirth));

                        reader.Close();
                        writer.Close();
                    }
                    break;
            }
        }
    }
}