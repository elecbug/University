using System.Collections;
using UnivSecurity;

DES.CreateDES();
DES.Service.Input = new BitArray(64, true);
DES.Service.Input[2] = false;
DES.Service.DebugMode = true;
DES.Service.Key = new BitArray(48, true);
DES.Service.Encrypt();

BitArray output = DES.Service.Output;

DES.Service.Input = output;
DES.Service.Decrypt();

output = DES.Service.Output;

for (int i = 0; i < 64; i++)
{
    Console.Write(output[i] ? "1 " : "0 ");
}

Console.WriteLine();