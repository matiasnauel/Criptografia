using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cifrado
{
    public class Hash
    {
        private string MenssageHash;
        public Hash(string hashMenssg)
        {
            this.MenssageHash = hashMenssg;
        }
        public string HashSimple()
        {
            string a = Binario_A_Decimal(MenssageHash);
            int b = (int.Parse(a) * 7) % 13;
            string c = Decimal_a_Binario(b);
            return c;
        }

        public string Decimal_a_Binario(int b)
        {
            var decimal_binario = Convert.ToString(b, 2);
            return decimal_binario;
            
        }

        public string Binario_A_Decimal(string message)
        {
            //Convertir de binario a decimal
            string binario_decimal = Convert.ToInt32(message, 2).ToString();
            return binario_decimal;
        }
    }
}
