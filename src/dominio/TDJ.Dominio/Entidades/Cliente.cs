using TDJ.Dominio.EntidadeBase;

namespace TDJ.Dominio.Entidades
{
    public class Cliente : Base
    {
        public Cliente(string nome, string email, string cPF)
        {
            Nome = nome;
            Email = email;
            CPF = cPF;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
    }
}
