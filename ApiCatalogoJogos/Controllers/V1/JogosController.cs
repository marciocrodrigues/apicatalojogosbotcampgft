using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    /// <summary>
    /// Controller para ações relacionadas a jogos
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Listar todos jogos", type: typeof(List<JogoViewModel>))]
        [SwaggerResponse(statusCode: 500, description: "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde.")]
        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> Obter(
            [FromQuery, Range(1, int.MaxValue)] int pagina = 1,
            [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var result = await _jogoService.Obter(pagina, quantidade);

            if (result.Any())
                return Ok(result);

            return NoContent();
        }

        /// <summary>
        /// Busca o jogo pelo identificador
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Lista o jogo pelo identificador", type: typeof(JogoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde.")]
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromRoute]Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo != null)
                return Ok(jogo);

            return NoContent();
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogoInputModel"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Jogo cadastro com sucesso", type: typeof(JogoViewModel))]
        [SwaggerResponse(statusCode: 422, description: "Já existe um jogo com este nome para produtora")]
        [SwaggerResponse(statusCode: 500, description: "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde.")]
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody]JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para produtora");
            }
        }

        /// <summary>
        /// Atualiza os dados de um jogo
        /// </summary>
        /// <param name="idJogo"></param>
        /// <param name="jogoInputModel"></param>
        /// <returns></returns>
        [SwaggerResponse( statusCode: 200, description: "Jogo atualizado com sucesso.")]
        [SwaggerResponse(statusCode: 404, description: "Não existe este jogo")]
        [SwaggerResponse(statusCode: 500, description: "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde.")]
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute]Guid idJogo, [FromBody]JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);

                return Ok("Jogo atualizado com sucesso.");
            }
            catch (JogoJaCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        /// <summary>
        /// Altera o preço de um jogo
        /// </summary>
        /// <param name="idJogo"></param>
        /// <param name="preco"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Preço do jogo atualizado com sucesso.")]
        [SwaggerResponse(statusCode: 404, description: "Não existe este jogo")]
        [SwaggerResponse(statusCode: 500, description: "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde.")]
        [HttpPatch("{idJogo:guid/preco/{preco:double}}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute]double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok("Preço do jogo atualizado com sucesso.");
            }
            catch (JogoJaCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        /// <summary>
        /// Apaga um jogo da base de dados
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Jogo removido com sucesso")]
        [SwaggerResponse(statusCode: 404, description: "Não existe este jogo")]
        [SwaggerResponse(statusCode: 500, description: "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde.")]
        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);

                return Ok("Jogo removido com sucesso");
            }
            catch (JogoJaCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}
