using System.Collections;
using UnivSecurity;

DES.CreateDES();
DES.Service.Input = new BitArray(64, true);
DES.Service.DebugMode = true;
DES.Service.Key = new BitArray(48, true);
DES.Service.Encrypt();

BitArray output = DES.Service.Output;

DES.Service.Input = output;
DES.Service.Decrypt();

output = DES.Service.Output;

Console.WriteLine(output.ToString());