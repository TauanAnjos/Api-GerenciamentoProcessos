﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GerenciamentoProcessos.Models;

public partial class Cliente
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }

    public virtual ICollection<Processo> Processos { get; set; } = new List<Processo>();
}