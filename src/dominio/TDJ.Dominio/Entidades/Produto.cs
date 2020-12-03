﻿using System;
using TDJ.Dominio.EntidadeBase;
using TDJ.Dominio.Interfaces;

namespace TDJ.Dominio.Entidades
{
    public class Produto : Base, IAggregateRoot
    {
        protected Produto() { }
        public Produto(string nome, bool ativo)
        {
            Nome = nome;
            Ativo = ativo;
        }

        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public Guid IdDoCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
