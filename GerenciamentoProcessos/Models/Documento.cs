﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GerenciamentoProcessos.Models;

public partial class Documento
{
    public Guid Id { get; set; }

    public Guid? ProcessoId { get; set; }

    public string Nome { get; set; }

    public string Tipo { get; set; }

    public string CaminhoArquivo { get; set; }

    public virtual Processo Processo { get; set; }
}