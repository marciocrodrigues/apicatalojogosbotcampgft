using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.InputModel
{
    /// <summary>
    /// Model para cadastro de jogo
    /// </summary>
    public class JogoInputModel
    {
        /// <summary>
        /// Nome jogo
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        /// <summary>
        /// Produtora criadora do jogo
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }
        /// <summary>
        /// Preco do jogo
        /// </summary>
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço deve ser de no mínimo 1 real e no máximo 1000 reais")]
        public double Preco { get; set; }
    }
}
