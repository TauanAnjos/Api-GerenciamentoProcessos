﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProcessos.Models;

public partial class GerenciamentoProcessosContext : DbContext
{
    public GerenciamentoProcessosContext(DbContextOptions<GerenciamentoProcessosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DistribuicaoProcesso> DistribuicaoProcessos { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Prazo> Prazos { get; set; }

    public virtual DbSet<Processo> Processos { get; set; }

    public virtual DbSet<Procurador> Procuradors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83F8C8404F0");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Email, "UQ__Cliente__AB6E6164BDC4F07A").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .HasColumnName("senha");
        });

        modelBuilder.Entity<DistribuicaoProcesso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Distribu__3213E83F079AE394");

            entity.ToTable("DistribuicaoProcesso");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.DataTransferencia)
                .HasColumnType("datetime")
                .HasColumnName("data_transferencia");
            entity.Property(e => e.ProcessoId).HasColumnName("processo_id");
            entity.Property(e => e.ProcuradorDestinoId).HasColumnName("procurador_destino_id");
            entity.Property(e => e.ProcuradorOrigemId).HasColumnName("procurador_origem_id");

            entity.HasOne(d => d.Processo).WithMany(p => p.DistribuicaoProcessos)
                .HasForeignKey(d => d.ProcessoId)
                .HasConstraintName("FK__Distribui__proce__08B54D69");

            entity.HasOne(d => d.ProcuradorDestino).WithMany(p => p.DistribuicaoProcessoProcuradorDestinos)
                .HasForeignKey(d => d.ProcuradorDestinoId)
                .HasConstraintName("FK__Distribui__procu__0A9D95DB");

            entity.HasOne(d => d.ProcuradorOrigem).WithMany(p => p.DistribuicaoProcessoProcuradorOrigems)
                .HasForeignKey(d => d.ProcuradorOrigemId)
                .HasConstraintName("FK__Distribui__procu__09A971A2");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3213E83FF18F214F");

            entity.ToTable("Documento");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CaminhoArquivo)
                .HasMaxLength(255)
                .HasColumnName("caminho_arquivo");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.ProcessoId).HasColumnName("processo_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Processo).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.ProcessoId)
                .HasConstraintName("FK__Documento__proce__07C12930");
        });

        modelBuilder.Entity<Prazo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prazo__3213E83FD48CAF51");

            entity.ToTable("Prazo");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.DataVencimento).HasColumnName("data_vencimento");
            entity.Property(e => e.ProcessoId).HasColumnName("processo_id");
            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasConversion<int>(); ;
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Processo).WithMany(p => p.Prazos)
                .HasForeignKey(d => d.ProcessoId)
                .HasConstraintName("FK__Prazo__processo___06CD04F7");
        });

        modelBuilder.Entity<Processo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Processo__3213E83F39D6CE36");

            entity.ToTable("Processo");

            entity.HasIndex(e => e.Numero, "UQ__Processo__FC77F211C5CD991E").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Assunto)
                .HasMaxLength(255)
                .HasColumnName("assunto");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Numero)
                .HasMaxLength(255)
                .HasColumnName("numero");
            entity.Property(e => e.OrgaoResponsavel)
                .HasMaxLength(255)
                .HasColumnName("orgao_responsavel");
            entity.Property(e => e.ProcuradorId).HasColumnName("procurador_id");
            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasConversion<int>(); ;

            entity.HasOne(d => d.Cliente).WithMany(p => p.Processos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Processo__client__05D8E0BE");

            entity.HasOne(d => d.Procurador).WithMany(p => p.Processos)
                .HasForeignKey(d => d.ProcuradorId)
                .HasConstraintName("FK__Processo__procur__04E4BC85");
        });

        modelBuilder.Entity<Procurador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Procurad__3213E83FE71B63DB");

            entity.ToTable("Procurador");

            entity.HasIndex(e => e.Email, "UQ__Procurad__AB6E61642F85ACD8").IsUnique();

            entity.HasIndex(e => e.Oab, "UQ__Procurad__C2F80E0A4DF9ED6E").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.Oab)
                .HasMaxLength(255)
                .HasColumnName("oab");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}