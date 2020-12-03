﻿using System;
using TDJ.Dominio.EntidadeBase;

namespace TDJ.Dominio.Entidades
{
    public class Cliente : Base
    {
        protected Cliente() { }
        public Cliente(string nome, string email, string cpf)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Guid IdDoProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
