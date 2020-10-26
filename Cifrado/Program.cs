using System;
using System.Collections.Generic;

namespace Cifrado
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ListaDeVariables = new List<string>();
            Console.WriteLine("enter binary message..");
            string MessageBinary = Console.ReadLine();
            Console.WriteLine("Enter private key");
            string PrivateKey = Console.ReadLine();
            Encryption NewEncryp = new Encryption(MessageBinary,PrivateKey);
            var e= NewEncryp.Split(MessageBinary,4);
            Int32 operacion = 0;
            string binario_decimal_mensaje;
            string binario_decimal_key = Convert.ToInt32(PrivateKey, 2).ToString();
 
            foreach (var item in e)
            {
                binario_decimal_mensaje = Convert.ToInt32(item, 2).ToString(); ;
                operacion = int.Parse(binario_decimal_mensaje) ^ int.Parse(binario_decimal_key);
                var decimal_binario = Convert.ToString(operacion, 2);
                ListaDeVariables.Add(decimal_binario);
            }

            foreach (var item3 in ListaDeVariables)
            {
                string addd =NewEncryp.Tablecypher(item3);
                Console.WriteLine("El mensaje encriptado es: "+addd);
            }
            // Hashear el mensaje 
            Hash newHash = new Hash(MessageBinary);
            string resultado = newHash.HashSimple();
            Console.WriteLine("El mensaje Hasheado es :" + resultado);
            Console.ReadKey();

        }
      
    }
}
