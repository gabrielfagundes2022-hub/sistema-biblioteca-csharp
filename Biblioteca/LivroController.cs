using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class LivroController
    {
        // atributos
        private List<LivroModel> _colecaoLivros;

        private LivroModel _livro;
        private LivroView _livroView;

        private int _posicao;

        // construtor
        public LivroController()
        {
            this._livroView = new LivroView();
            this._livro = new LivroModel();

            this._colecaoLivros = new List<LivroModel>();
            // adiciona 1 livro na coleção para testarmos a consulta posteriormente
            this._colecaoLivros.Add(
                new LivroModel("123", "Faca", "Jo Nesbo", "Policial", 450)
            );
        }

        public void ExecutarCRUD()
        {
            string resp;

            // começa com um livro vazio a cada vez que o CRUD é executado
            this._livro = new LivroModel();

            this._livroView.MostrarFormulario();

            // pergunta o código
            this._livroView.EntrarDados("PK", this._livro);

            // se não digitou nada, volta para o menu
            if (string.IsNullOrWhiteSpace(this._livro.Isbn)) return;

            // busca pelo código
            bool achei = this.Buscar(this._livro.Isbn);

            // se o código NÃO FOI encontrado
            if (!achei)
            {
                // informa que NÃO EXISTE e pergunta se deseja cadastrar
                resp = this._livroView.Perguntar("Não existe. Cadastrar (S/N) : ");

                // se SIM
                if (resp.ToLower() == "s")
                {
                    // pergunta demais dados
                    this._livroView.EntrarDados("DT", this._livro);

                    // pergunta se confirma o cadastro
                    resp = this._livroView.Perguntar("Confirma cadastro (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // adiciona o novo registro
                        this._colecaoLivros.Add(this._livro);
                        this._livroView.Mensagem("Livro cadastrado! Acione uma tecla.");
                    }
                }
            }
            // se o codigo FOI encontrado
            else
            {
                // mostra os dados do registro encontrado
                this._livroView.MostrarDados(this._colecaoLivros[this._posicao]);

                // pergunta se deseja alterar/excluir/voltar
                resp = this._livroView.Perguntar("[A]lterar [E]xcluir [V]oltar : ");

                // se deseja ALTERAR
                if (resp.ToLower() == "a")
                {
                    // pergunta os novos dados
                    // (usa um livro novo para não perder os dados antigos se o usuário desistir)
                    LivroModel novo = new LivroModel();
                    novo.Isbn = this._livro.Isbn;
                    this._livroView.LimparDados();
                    this._livroView.EntrarDados("DT", novo);

                    // pergunta se confirma alteração
                    resp = this._livroView.Perguntar("Confirma alteração (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // atualiza dos dados do registro
                        this._colecaoLivros[this._posicao] = novo;
                        this._livroView.Mensagem("Livro alterado! Acione uma tecla.");
                    }
                }
                // se deseja EXCLUIR
                else if (resp.ToLower() == "e")
                {
                    // pergunta se confirma exclusão
                    resp = this._livroView.Perguntar("Confirma exclusão (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // exclui o registro
                        this._colecaoLivros.RemoveAt(this._posicao);
                        this._livroView.Mensagem("Livro excluído! Acione uma tecla.");
                    }
                }
            }
        }


        private bool Buscar(string isbn)
        {
            bool encontrei = false;

            for (int i = 0; i < this._colecaoLivros.Count; i++)
            {
                if (this._colecaoLivros[i].Isbn == isbn)
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
