using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class LivroView
    {
        // atributos
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;
        private List<string> _campos;

        // construtor
        public LivroView()
        {
            this._campos = new List<string>();
            this._campos.Add(" ISBN    :");
            this._campos.Add(" Título  :");
            this._campos.Add(" Autor   :");
            this._campos.Add(" Gênero  :");
            this._campos.Add(" Páginas :");

            this._colIni = 24;
            this._linIni = 4;
            this._colFin = _colIni + this._campos[0].Length + 1 + 30;
            // +1 para colocar o traçado vertical direito depois dos :
            // +30 para ter espaço para o usuário digitar os dados
            this._linFin = _linIni + this._campos.Count + 1 + 2;
            // +1 para colocar o traçado horizontal na linha após o último campo
            // +2 para podermos usar um Titulo e um espaço para perguntas
            this._colDados = this._colIni + this._campos[0].Length + 1;
            this._linDados = this._linIni + 2;
        }

        public void MostrarFormulario()
        {

            Tela tela = new Tela();
            tela.MontarMoldura(
                this._colIni, this._linIni,
                this._colFin, this._linFin,
                "Cadastro de Livros"
            );


            int linha = this._linDados;
            for (int i = 0; i < this._campos.Count; i++)
            {
                Console.SetCursorPosition(this._colIni + 1, linha);
                Console.Write(this._campos[i]);
                linha++;
            }

            // ou podemos usar o comando foreach
            /*
            foreach (string campo in this._campos)
            {
                Console.SetCursorPosition(this._colIni+1, linha);
                Console.Write(campo);
                linha++;
            }
            */
        }


        public void EntrarDados(string qual, LivroModel livro)
        {
            if (qual == "PK")
            {
                // pergunta a chave primária (código)
                Console.SetCursorPosition(this._colDados,  this._linDados);
                livro.Isbn = Console.ReadLine();
            }
            else if (qual == "DT")
            {
                // pergunta todos os outros dados

                Console.SetCursorPosition(this._colDados, this._linDados + 1);
                livro.Titulo = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados + 2);
                livro.Autor = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados + 3);
                livro.Genero = Console.ReadLine();

                // as páginas são um número, então tentamos converter o que foi digitado
                // se o usuário digitar algo que não é número, fica com 0 página
                Console.SetCursorPosition(this._colDados, this._linDados + 4);
                int paginas;
                if (!int.TryParse(Console.ReadLine(), out paginas)) paginas = 0;
                livro.Paginas = paginas;
            }
        }


        // mostra na tela os dados de um livro que já está cadastrado
        public void MostrarDados(LivroModel livro)
        {
            Console.SetCursorPosition(this._colDados, this._linDados);
            Console.Write(livro.Isbn);

            Console.SetCursorPosition(this._colDados, this._linDados + 1);
            Console.Write(livro.Titulo);

            Console.SetCursorPosition(this._colDados, this._linDados + 2);
            Console.Write(livro.Autor);

            Console.SetCursorPosition(this._colDados, this._linDados + 3);
            Console.Write(livro.Genero);

            Console.SetCursorPosition(this._colDados, this._linDados + 4);
            Console.Write(livro.Paginas);
        }


        // apaga os dados da tela (menos o ISBN) para digitar de novo
        public void LimparDados()
        {
            Tela tela = new Tela();
            tela.LimparArea(
                this._colDados, this._linDados + 1,
                this._colFin - 1, this._linDados + this._campos.Count - 1
            );
        }


        public string Perguntar(string pergunta)
        {
            string resposta = "";

            this.LimparMensagem();
            Console.SetCursorPosition(this._colIni + 2, this._linFin - 1);
            Console.Write(pergunta);
            resposta = Console.ReadLine();

            return resposta;
        }


        // mostra um aviso e espera o usuário acionar uma tecla
        public void Mensagem(string mensagem)
        {
            this.LimparMensagem();
            Console.SetCursorPosition(this._colIni + 2, this._linFin - 1);
            Console.Write(mensagem);
            Console.ReadKey();
        }


        // apaga a linha de perguntas/avisos que fica no rodapé do formulário
        private void LimparMensagem()
        {
            Tela tela = new Tela();
            tela.LimparArea(
                this._colIni + 1, this._linFin - 1,
                this._colFin - 1, this._linFin - 1
            );
        }


    }
}
