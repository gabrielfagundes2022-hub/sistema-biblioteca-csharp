using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class LivroModel
    {
        // atributos
        private string _isbn;
        private string _titulo;
        private string _autor;
        private string _genero;
        private int _paginas;

        // propriedades
        public string Isbn { get => _isbn; set => _isbn = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Autor { get => _autor; set => _autor = value; }
        public string Genero { get => _genero; set => _genero = value; }
        public int Paginas { get => _paginas; set => _paginas = value; }


        // construtores
        public LivroModel(string isbn, string titulo, string autor, string genero, int paginas)
        {
            this.Isbn = isbn;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Genero = genero;
            this.Paginas = paginas;
        }

        public LivroModel()
        {
            this.Isbn = "";
            this.Titulo = "";
            this.Autor = "";
            this.Genero = "";
            this.Paginas = 0;
        }

    }
}
