using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Cifrado
{
    public class Encryption
    {
        private readonly string Private_Key;
        private readonly string Menssage;
        private Dictionary<string, string> TableCypher;
        public Encryption(string priv_key,string Msg)
        {
            this.Private_Key = priv_key;
            this.Menssage = Msg;
            TableCypher = new Dictionary<string, string>();
        }
        public List<string> cifradoSimple()
        {
            //Inicializamos una lista de enteros para utilizarlo mas tarde
            List<string> Resultados2 = new List<string>();
            //Convertimos de binario a decimal
            var mensaje_a_decimal = Convert.ToInt32(Menssage, 2).ToString();
            var clave_a_decimal = Convert.ToInt32(Menssage, 2).ToString();
            //Dividimos la cadena en 4 bits para realizar las operaciones
            IEnumerable<string> resultados = Split(Menssage, 4);
            //Recorremos la lista y realizamos la operacion xor
            int operacion=0;
            string decimalBinario;
            string nuevoFormato;
            foreach (var item in resultados)
            {
                //realizamos la operacion xor
                operacion = Convert.ToInt32(item) ^ Convert.ToInt32(clave_a_decimal);
                //Convertimos el resultado nuevamente a binario
                decimalBinario = Convert.ToString(operacion);
                //Le agregamos 0 de lado izquierdo 
                nuevoFormato = int.Parse(decimalBinario).ToString("D4");
                //Lo agregamos a la lista
                Resultados2.Add(decimalBinario);
            }
            return lookupTable(Resultados2);
          
           


        }

        public string Tablecypher(string codigo)
        {
            string valorDevuelvo = "";
            TableCypher.Add("0000", "0011");
            TableCypher.Add("0001", "0100");
            TableCypher.Add("0010", "0101");
            TableCypher.Add("0011", "0110");
            TableCypher.Add("0100", "0111");
            TableCypher.Add("0101", "1001");
            TableCypher.Add("0110", "1101");
            TableCypher.Add("0111", "1111");
            TableCypher.Add("1000", "1100");
            TableCypher.Add("1001", "1110");
            TableCypher.Add("1010", "1011");
            TableCypher.Add("1011", "1010");
            TableCypher.Add("1100", "1000");
            TableCypher.Add("1101", "0001");
            TableCypher.Add("1110", "0010");
            TableCypher.Add("1111", "0000");
            foreach (KeyValuePair<string,string> item in TableCypher)
            {
                if(item.Key ==codigo)
                {
                    valorDevuelvo = item.Value;
                }
               
            }

            return valorDevuelvo;
        }
        public List<string> lookupTable(List<string> result)
        {

            List<string> resultado2 = new List<string>();
            foreach (var item in result)
            {
                foreach (KeyValuePair<string, string> item2 in TableCypher)
                {
                    if (item2.Key == item)
                    {
                        resultado2.Add(item2.Value);
                    }
                }
            }
            return resultado2;


        }
        public  IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
        

    }
}
