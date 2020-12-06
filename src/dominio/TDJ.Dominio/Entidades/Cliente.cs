using FluentValidation;
using System;
using TDJ.Dominio.EntidadeBase;
using TDJ.Dominio.Interfaces;

namespace TDJ.Dominio.Entidades
{
    public class Cliente : Base, IAggregateRoot
    {
        protected Cliente() { }

        public Cliente(Guid id, string nome, string email, string cPF, Guid idDoProduto, Produto produto)
        {
            Id = id;
            Nome = nome;
            Email = email;
            CPF = cPF;
            IdDoProduto = idDoProduto;
            Produto = produto;
        }

        public Cliente(string nome, string email, string cpf, Guid idDoProduto)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            IdDoProduto = idDoProduto;
            CPF = cpf;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public Guid IdDoProduto { get; private set; }
        public Produto Produto { get; private set; }
        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AlterarCPF(string cpf)
        {
            CPF = cpf;
        }

        public void AlterarEmail(string email)
        {
            Email = email;
        }

        public override bool Valido()
        {
            ValidationResult = new ValidarCliente().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class ValidarCliente : AbstractValidator<Cliente>
    {
        private int TAMANHO_MAX_NOME = 250;
        private int TAMANHO_MAX_EMAIL = 250;
        public ValidarCliente()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome deve ser preenchido")
                .MaximumLength(TAMANHO_MAX_NOME)
                .WithMessage($"O nome deve ter no máximo {TAMANHO_MAX_NOME} caracteres");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O email deve ser preenchido.")
                .MaximumLength(TAMANHO_MAX_EMAIL)
                .WithMessage($"Tamanho máximo do email é de {TAMANHO_MAX_EMAIL} caracteres.")
                .EmailAddress()
                .When(e => !string.IsNullOrEmpty(e.Email))
                .When(e => e?.Email?.Length <= TAMANHO_MAX_EMAIL)
                .Must(ValidarEmail)
                .WithMessage("Digite um email válido.");

            RuleFor(c => c.CPF)
                .NotEmpty()
                .WithMessage("O CPF deve ser preenchido")
                .Must(ValidarCPF)
                .WithMessage("Preencha um CPF válido.");

            //RuleFor(c => c.IdDoProduto)
            //   .NotEmpty()
            //   .WithMessage("Id de produto deve ser preenchido.")
            //   .Must(ValidarIdDoProduto)
            //   .WithMessage("Id de produto inválido");

        }
        public bool ValidarEmail(string email)
        {
            return (email.Contains("@") && email.Contains(".com")) ? true : false;


        }
        public bool ValidarCPF(string cpf)
        {
            if( string.IsNullOrEmpty(cpf) )
                return true;

            return cpf.Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).Length == 11;
        }
        public bool ValidarIdDoProduto(Guid guid)
        {
            return guid == null ? false : true;

        }
    }
}
