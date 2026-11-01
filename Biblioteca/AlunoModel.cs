using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoModel
    {
        // atributos
        private string _matricula;
        private string _nome;
        private string _email;
        private string _telefone;

        // propriedades
        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }


        // construtores
        public AlunoModel(string matricula, string nome, string email, string telefone)
        {
            this.Matricula = matricula;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }

        public AlunoModel()
        {
            this.Matricula = "";
            this.Nome = "";
            this.Email = "";
            this.Telefone = "";
        }


    }
}
