using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiForPeople.Entity;

namespace WebApiForPeople.Models
{
    public class FuncionarioModels
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAtualizacao { get; set; }
        public Endereco enderecos { get; set; }
        public string cpf { get; set; }
        public int idade { get; set; }

        public FuncionarioModels(int id, string nome, string cpf, int idade, Endereco enderecos)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.idade = idade;
            this.enderecos = enderecos;
        }

        public void update(int id, string nome, string cpf, int idade, Endereco enderecos)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.idade = idade;
            this.dataAtualizacao = DateTime.Now;
            this.enderecos = enderecos;
        }
    }
}