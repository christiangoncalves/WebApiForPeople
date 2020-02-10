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
        public JObject Create([FromBody] JObject a)
        {
            try
            {
                Endereco endereco = new Endereco(a);

                FuncionarioModels func = new FuncionarioModels((int)a["id"], (string)a["nome"], (string)a["cpf"], (int)a["idade"], endereco);
                func.dataCriacao = DateTime.Now;
                funcionarios.Add(func);

                String success = "Funcionario criado com sucesso";
                JObject successJson = new JObject();
                successJson["Success"] = success;
                return successJson;
            }
            catch (Exception e)
            {
                String error = e.Message;
                JObject errorJson = new JObject();
                errorJson["Error"] = error;
                errorJson["Ação"] = "Verifique se os campos do Json são iguais aos campos permitidos pela requisição!";
                return errorJson;
            }
            
        }

        [HttpPost]
        public JObject Destroy([FromBody] int id)
        {
            bool aux = false;

            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].id == id)
                {
                    funcionarios.RemoveAt(i);
                    aux = true;

                    String success = "Funcionario deletado com sucesso";
                    JObject successJson = new JObject();
                    successJson["Success"] = success;
                    return successJson;

                }
            }

            if (!aux)
            {
                String e = "Funcionário nao encontrado!";
                JObject error = new JObject();
                error["Error"] = e;

                return error;
            }

            return null;
        }

        [HttpPost]
        public JObject Update([FromBody] JObject a)
        {
            try
            {
                Endereco endereco = new Endereco(a);
                bool aux = false;

                for (int i = 0; i < funcionarios.Count; i++)
                {
                    if (funcionarios[i].id == (int)a["id"])
                    {
                        funcionarios[i].update((int)a["id"], (string)a["nome"], (string)a["cpf"], (int)a["idade"], endereco);
                        aux = true;

                        String success = "Funcionario Atualizado com sucesso";
                        JObject successJson = new JObject();
                        successJson["Success"] = success;
                        return successJson;
                    }
                }
                if (!aux)
                {
                    String e = "Funcionário nao encontrado!";
                    JObject error = new JObject();
                    error["Error"] = e;

                    return error;
                }
                return null;
            }
            catch (Exception e)
            {
                String error = e.Message;
                JObject errorJson = new JObject();
                errorJson["Error"] = error;
                errorJson["Ação"] = "Verifique se os campos do Json são iguais aos campos permitidos pela requisição!";
                return errorJson;
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
