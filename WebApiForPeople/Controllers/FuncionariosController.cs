using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiForPeople.Models;
using Newtonsoft.Json;
using WebApiForPeople.Entity;

namespace WebApiForPeople.Controllers
{
    public class FuncionariosController : ApiController
    {
        private static List<FuncionarioModels> funcionarios = new List<FuncionarioModels>();

        [HttpGet]
        public JObject List()
        {
            return convertToJObject(funcionarios);
        }

        [HttpGet]
        public JObject Show(int id)
        {
            List<FuncionarioModels> auxFunc = new List<FuncionarioModels>();

            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].id == id)
                {
                    auxFunc.Add(funcionarios[i]);
                    return convertToJObject(auxFunc);
                }
            }

            if (auxFunc.Count == 0)
            {
                String e = "Funcionário nao encontrado!";
                JObject error = new JObject();
                error["Error"] = e;

                return error;
            }

            return null;
        }

        [HttpPost]
        public void Create([FromBody] JObject a)
        {
            Endereco endereco = new Endereco(a);
            FuncionarioModels func = new FuncionarioModels((int)a["id"], (string)a["nome"], (string)a["cpf"], (int)a["idade"], endereco);
            func.dataCriacao = DateTime.Now;
            funcionarios.Add(func);
        }

        [HttpPost]
        public void Destroy([FromBody] int id)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].id == id)
                {
                    funcionarios.RemoveAt(i);
                }
            }
        }

        [HttpPost]
        public void Update([FromBody] JObject a)
        {
            Endereco endereco = new Endereco(a);

            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].id == (int)a["id"])
                {
                    funcionarios[i].update((int)a["id"], (string)a["nome"], (string)a["cpf"], (int)a["idade"], endereco);
                }
            }
        }

        [NonAction]
        public JObject convertToJObject(List<FuncionarioModels> funcionario)
        {
            JObject funcionariosJson = new JObject();
            funcionariosJson["funcionario"] = JToken.FromObject(funcionario);
            return funcionariosJson;
        }
    }   
}
