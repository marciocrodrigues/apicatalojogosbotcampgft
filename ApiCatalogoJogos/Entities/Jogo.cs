using System;

namespace ApiCatalogoJogos.Entities
{
    public class Jogo : Entidade
    {
        public Jogo(string nome, string produtora, double preco)
        {
            Nome = nome;
            Produtora = produtora;
            Preco = preco;
        }

        public string Nome { get; private set; }
        public string Produtora { get; private set; }
        public double Preco { get; private set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarProdutora(string produtora)
        {
            Produtora = produtora;
        }

        public void AlterarPreco(double preco)
        {
            Preco = preco;
        }
    }
}
