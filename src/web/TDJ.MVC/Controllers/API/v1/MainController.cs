using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TDJ.Dominio.Entidades;

namespace TDJ.MVC.Controllers.API.v1
{

    [ApiController]
    public class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();
        protected IActionResult RespostaCustomizada(object resultado = null)
        {
            if( OperacaoValida() )
            {
                return Ok(resultado);
            }
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }
        protected IActionResult RespostaCustomizada(ResultadoCustomizado resultadoCustomizado)
        {
            if( resultadoCustomizado.Erros.Mensagens.Count != 0)
            {
                var erros = resultadoCustomizado.Erros.Mensagens;
                foreach( var erro in erros )
                {
                    AdicionarErro(erro);
                }
            }
            return RespostaCustomizada(new { resultadoCustomizado.Mensagem, resultadoCustomizado.Objeto });
        }


        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }
        protected void AdicionarErro(string erro)
        {
            Erros.Add(erro);
        }
        protected void LimparErro()
        {
            Erros.Clear();
        }
    }
}
