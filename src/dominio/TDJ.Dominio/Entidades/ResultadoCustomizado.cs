using System.Collections.Generic;

namespace TDJ.Dominio.Entidades
{
    public class ResultadoCustomizado
    {
        public ResultadoCustomizado()
        {
            Erros = new Erros();
        }

        public bool Success { get; protected set; }
        public Erros Erros { get; protected set; }
        public string Mensagem { get; protected set; }
        public object Objeto { get; protected set; }
        public void AdicionarMensagensDeErro(string[] erros)
        {
            foreach( var erro in erros )
            {
                Erros.Mensagens.Add(erro);
            }
        }
        public void Sucesso(bool sucesso)
        {
            Success = sucesso;
        }
        public void AdicionarMensagem(string mensagem)
        {
            Mensagem = mensagem;
        }
        public void AdicionarObjeto(object obj)
        {
            Objeto = obj;
        }

    }
    public class Erros
    {
        public Erros()
        {
            Mensagens = new List<string>();
        }
        public List<string> Mensagens { get; protected set; }

    }
}
