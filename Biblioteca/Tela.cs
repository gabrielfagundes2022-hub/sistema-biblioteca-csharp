using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Tela
    {
        // atributos
        private ConsoleColor _corTexto;
        private ConsoleColor _corFundo;


        // métodos construtores com sobrecarga
        public Tela()
        {
            _corTexto = ConsoleColor.White;
            _corFundo = ConsoleColor.Black;
        }

        public Tela(ConsoleColor corTexto, ConsoleColor corFundo)
        {
            _corTexto = corTexto;
            _corFundo = corFundo;
        }


        // outros métodos

        public void ConfigurarTela()
        {
            Console.BackgroundColor = _corFundo;
            Console.ForegroundColor = _corTexto;
            Console.Clear();
        }

        public void LimparArea(int colIni, int linIni, int colFin, int linFin)
        {
            for (int col = colIni; col <= colFin; col++)
            {
                for (int lin = linIni; lin <= linFin; lin++)
                {
                    Console.SetCursorPosition(col, lin);
                    Console.Write(" ");
                }
            }
        }


        public void MontarMoldura(int colIni = 0, int linIni = 0,
            int colFin = 79, int linFin = 24, string titulo = "")
        { 
            // limpa a area para a nova janela
            this.LimparArea(colIni, linIni, colFin, linFin);

            // mostra o título da janela
            this.Centralizar(titulo, colIni+1, colFin-1, linIni+1);

            // desenha as bordas horizontais  (codigo 205)
            for (int coluna = colIni; coluna <= colFin; coluna++)
            {
                // borda superior
                Console.SetCursorPosition(coluna, linIni);
                Console.Write("═");
                // borda inferior
                Console.SetCursorPosition(coluna, linFin);
                Console.Write("═");
            }

            // desenha as bordas verticais (código 186)
            for(int linha = linIni; linha <= linFin; linha++)
            {
                // borda esquerda
                Console.SetCursorPosition(colIni, linha);
                Console.Write("║");
                // borda direita
                Console.SetCursorPosition(colFin, linha);
                Console.Write("║");
            }

            // desenha os cantos
            // canto superior esquerdo
            Console.SetCursorPosition(colIni, linIni);
            Console.Write("╔");  // codigo 201
            // canto superior direito
            Console.SetCursorPosition(colFin, linIni);
            Console.Write("╗");  // codigo 187
            // canto inferior esquerdo
            Console.SetCursorPosition(colIni, linFin);
            Console.Write("╚");   //  200
            // canto inferior direito
            Console.SetCursorPosition(colFin, linFin);
            Console.Write("╝"); // 188
        }

        public void Centralizar(string texto, int colIni, int colFin, int linha)
        {
            int coluna = colIni + ((colFin-colIni-texto.Length)/2);
            Console.SetCursorPosition(coluna, linha);
            Console.Write(texto);
        }


        public string MostrarMenu(List<string> menu, int colIni, int linIni)
        {
            string op;
            int colFin, linFin;

            // calcula a coluna e linha final a partir do tamanho do menu
            colFin = colIni + menu[0].Length+1;
            linFin = linIni + menu.Count+3;

            // desenha a moldura do menu
            this.MontarMoldura(colIni, linIni, colFin, linFin, "Menu");

            // mostra as opções do menu
            for (int i = 0; i < menu.Count; i++)
            {
                Console.SetCursorPosition(colIni + 1, linIni + 2 + i);
                Console.Write(menu[i]);
            }

            // pergunta qual opção o usuário deseja
            Console.SetCursorPosition(colIni+1, linFin-1);
            Console.Write(" Opção : ");
            op = Console.ReadLine();
            return op;        
        }

    }
}
