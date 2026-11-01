using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tela tela = new Tela(ConsoleColor.White, ConsoleColor.DarkBlue);
            tela.ConfigurarTela();

            LivroController livroController = new LivroController();
            AlunoController alunoController = new AlunoController();

            List<string> opcoes = new List<string>();
            opcoes.Add(" 1 - Livros      ");
            opcoes.Add(" 2 - Alunos      ");
            opcoes.Add(" 3 - Empréstimos ");
            opcoes.Add(" 4 - Relatórios  ");
            opcoes.Add(" 0 - Sair        ");

            string opcao;

            while (true)
            {
                tela.MontarMoldura(0,0,79,24,"Sistema de Biblioteca");
                opcao = tela.MostrarMenu(opcoes, 2, 2);

                if (opcao == "0") break;
                else if (opcao == "1") livroController.ExecutarCRUD();
                else if (opcao == "2") alunoController.ExecutarCRUD();
                else if (opcao == "3" || opcao == "4")
                {
                    tela.Centralizar("Em construção! Acione uma tecla.",
                        1, 78, 23);
                    Console.ReadKey();
                }
                else
                {
                    tela.Centralizar("Opção inválida! Acione uma tecla.",
                        1, 78, 23);
                    Console.ReadKey();
                }
            }

            Console.Clear();
            Console.WriteLine("Adeus...");
        }
    }
}
