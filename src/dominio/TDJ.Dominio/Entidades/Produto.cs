using TDJ.Dominio.EntidadeBase;

namespace TDJ.Dominio.Entidades
{
    public class Produto : Base
    {
        public Produto(string nome, bool ativo)
        {
            Nome = nome;
            Ativo = ativo;
        }

        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
