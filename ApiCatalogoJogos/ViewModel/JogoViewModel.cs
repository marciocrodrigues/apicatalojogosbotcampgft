using System;

namespace ApiCatalogoJogos.ViewModel
{
    /// <summary>
    /// Model de dados para retorno
    /// </summary>
    public class JogoViewModel
    {
        /// <summary>
        /// Identificador do jogo
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Nome do jogo
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Produtora criadora do jogo
        /// </summary>
        public string Produtora { get; set; }
        /// <summary>
        /// Preco do jogo
        /// </summary>
        public double Preco { get; set; }
    }
}
