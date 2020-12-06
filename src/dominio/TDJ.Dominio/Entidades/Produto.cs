using FluentValidation;
using System;
using TDJ.Dominio.EntidadeBase;
using TDJ.Dominio.Interfaces;

namespace TDJ.Dominio.Entidades
{
    public class Produto : Base, IAggregateRoot
    {
        protected Produto() { }
        public Produto(string nome, bool ativo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Ativo = ativo;
        }

        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        //public DateTime DeletadoEm { get; set; }
        public Guid IdDoCliente { get; private set; }
        public Cliente Cliente { get; private set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AlterarAtivo(bool ativo)
        {
            Ativo = ativo;
        }

        public override bool Valido()
        {
            ValidationResult = new ValidacaoDeProduto().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class ValidacaoDeProduto : AbstractValidator<Produto>
    {

        private readonly int TAMANHO_MAXIMO_NOME = 250;
        public ValidacaoDeProduto()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O Nome deve ser preenchido.")
                .MaximumLength(TAMANHO_MAXIMO_NOME).WithMessage($"O nome deve possuir no máximo {TAMANHO_MAXIMO_NOME} caracteres");

            RuleFor(v => v.Ativo)
                .NotNull().WithMessage("Deve informar se o produto está ativo.");

        }
    }
}
