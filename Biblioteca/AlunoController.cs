using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoController
    {
        // atributos
        private List<AlunoModel> _colecaoAlunos;
        private int _posicao;

        // construtor
        public AlunoController()
        {
            this._colecaoAlunos = new List<AlunoModel>();
            // adiciona 1 aluno na coleção para testarmos a consulta posteriormente
            this._colecaoAlunos.Add(
                new AlunoModel("123","Zé Colmeia","zecolmeia@gmail.com","99967-8976")
            );
        }

        public void ExecutarCRUD()
        {
            AlunoModel aluno = new AlunoModel();
            AlunoView view = new AlunoView();
            string resp;


            view.MostrarFormulario();

            // pergunta o código
            view.EntrarDados("PK", aluno);

            // se não digitou nada, volta para o menu
            if (string.IsNullOrWhiteSpace(aluno.Matricula)) return;

            // busca pelo código
            bool achei = this.Buscar(aluno.Matricula);

            // se o código NÃO FOI encontrado
            if (!achei)
            {
                // informa que NÃO EXISTE e pergunta se deseja cadastrar
                resp = view.Perguntar("Não existe. Cadastrar (S/N) : ");

                // se SIM
                if (resp.ToLower() == "s")
                {
                    // pergunta demais dados
                    view.EntrarDados("DT", aluno);

                    // pergunta se confirma o cadastro
                    resp = view.Perguntar("Confirma cadastro (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // adiciona o novo registro
                        this._colecaoAlunos.Add(aluno);
                        view.Mensagem("Aluno cadastrado! Acione uma tecla.");
                    }
                }
            }
            // se o codigo FOI encontrado
            else
            {
                // mostra os dados do registro encontrado
                view.MostrarDados(this._colecaoAlunos[this._posicao]);

                // pergunta se deseja alterar/excluir/voltar
                resp = view.Perguntar("[A]lterar [E]xcluir [V]oltar : ");

                // se deseja ALTERAR
                if (resp.ToLower() == "a")
                {
                    // pergunta os novos dados
                    // (usa um aluno novo para não perder os dados antigos se o usuário desistir)
                    AlunoModel novo = new AlunoModel();
                    novo.Matricula = aluno.Matricula;
                    view.LimparDados();
                    view.EntrarDados("DT", novo);

                    // pergunta se confirma alteração
                    resp = view.Perguntar("Confirma alteração (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // atualiza dos dados do registro
                        this._colecaoAlunos[this._posicao] = novo;
                        view.Mensagem("Aluno alterado! Acione uma tecla.");
                    }
                }
                // se deseja EXCLUIR
                else if (resp.ToLower() == "e")
                {
                    // pergunta se confirma exclusão
                    resp = view.Perguntar("Confirma exclusão (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // exclui o registro
                        this._colecaoAlunos.RemoveAt(this._posicao);
                        view.Mensagem("Aluno excluído! Acione uma tecla.");
                    }
                }
            }
        }


        private bool Buscar(string matricula)
        {
            bool encontrei = false;

            for (int i = 0; i < this._colecaoAlunos.Count; i++)
            {
                if (this._colecaoAlunos[i].Matricula == matricula)
                {
                    this._posicao = i;
                    encontrei = true;
                    break;
                }
            }

            return encontrei;
        }


    }
}
