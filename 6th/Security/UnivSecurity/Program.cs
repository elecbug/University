using System.Collections;
using System.Text;

namespace UnivSecurity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("How to Use:\n[Input file] -e|-d [Output file] [Hexa-key]");

            string command = Console.ReadLine()!;
            switch (command.Split(' ')[1].ToUpper())
            {
                // 암호화 모드
                case "-E":
                    {
                        // 커맨드를 사용하기 좋게 나눔
                        string file = command.Split(' ')[0];
                        BitArray key = new BitArray(DESSupporter.HexToByte(command.Split(' ')[3]));

                        // 파일을 바이너리로 읽음
                        FileStream stream = File.OpenRead(file);
                        BinaryReader reader = new BinaryReader(stream);

                        // 8 bit(1 B) 씩나누고, 8 B (64 bit) 단위로 합쳐 64 bit 리스트를 형성
                        byte[] bytes = reader.ReadBytes((int)stream.Length);
                        List<BitArray> input = DESSupporter.To64Bits(new BitArray(bytes));

                        // des 리스트를 만들고 암호화 output 리스트도 만듦
                        List<DES> des1 = new List<DES>();
                        List<BitArray> output = new List<BitArray>();

                        // Initial Vector - 편의상 111...111로 생성
                        BitArray iv = new BitArray(64, true);
                        input[0] = input[0].Xor(iv);

                        // 각 리스트의 원소에 input 64 bit와 키를 넣고 암호화 후 output 리스트에 결과를 추가
                        for (int i = 0; i < input.Count; i++)
                        {
                            des1.Add(new DES()
                            {
                                Input = input[i],
                                Key = key,
                            });

                            des1[i].Encrypt();
                            output.Add(des1[i].Output);

                            if (i < input.Count - 1)
                            {
                                input[i + 1] = input[i + 1].Xor(output[i]);
                            } 
                        }

                        // 모두 합쳐서 최종 파일로 생성
                        BinaryWriter writer = new BinaryWriter(File.Create(command.Split(' ')[2]));
                        writer.Write(DESSupporter.ToByteArray(output));

                        reader.Close();
                        writer.Close();
                    }
                    break;
                    // 복호화 모드
                case "-D":
                    {
                        // 커맨드를 사용하기 좋게 나눔
                        string file = command.Split(' ')[0];
                        BitArray key = new BitArray(DESSupporter.HexToByte(command.Split(' ')[3]));

                        // 파일을 바이너리로 읽음
                        FileStream stream = File.OpenRead(file);
                        BinaryReader reader = new BinaryReader(stream);

                        // 8 bit(1 B) 씩나누고, 8 B (64 bit) 단위로 합쳐 64 bit 리스트를 형성
                        byte[] bytes = reader.ReadBytes((int)stream.Length);
                        List<BitArray> encryption = DESSupporter.To64Bits(new BitArray(bytes));

                        // des 리스트를 만들고 복호화 output 리스트도 만듦
                        List<DES> des2 = new List<DES>();
                        List<BitArray> rebirth = new List<BitArray>();

                        // Initial Vector - 편의상 111...111로 생성
                        BitArray iv = new BitArray(64, true);

                        // 각 리스트의 원소에 암호화된 input 64 bit와 키를 넣고 복호화 후 output 리스트에 결과를 추가
                        for (int i = 0; i < encryption.Count; i++)
                        {
                            des2.Add(new DES()
                            {
                                Input = encryption[i],
                                Key = key,
                            });

                            des2[i].Decrypt();

                            if (i == 0)
                            {
                                des2[i].Output = des2[i].Output.Xor(iv);
                            }
                            else
                            {
                                des2[i].Output = des2[i].Output.Xor(des2[i - 1].Input);
                            }

                            rebirth.Add(des2[i].Output);
                        }

                        // 모두 합쳐서 최종 파일로 생성
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