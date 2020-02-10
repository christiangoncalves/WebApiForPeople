using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiForPeople.Entity
{
    public class Endereco
    {
        public List<string> logradouro { get; set; }

        public Endereco(object a)
        {
            List<string> enderecosAux = new List<string>();
            dynamic array = a;

            foreach (dynamic item in array.endereco)
            {
                enderecosAux.Add((string)item);
            }
            this.logradouro = enderecosAux;

        }
    }
}