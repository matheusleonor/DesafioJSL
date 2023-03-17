using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EJSL.Models;

public partial class EjslContext : DbContext
{
    public EjslContext()
    {
    }

    public EjslContext(DbContextOptions<EjslContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carga> Cargas { get; set; }

    public virtual DbSet<Motorista> Motorista { get; set; }

    public virtual DbSet<Rota> Rota { get; set; }

    public virtual DbSet<Veiculo> Veiculos { get; set; }

    public virtual DbSet<Viagem> Viagems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MATHEUS;Initial Catalog=EJSL;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carga__3214EC07731EBB5C");

            entity.ToTable("Carga");

            entity.HasIndex(e => e.Codigo, "UQ__Carga__06370DAC031264BC").IsUnique();

            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Destino)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Origem)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Produto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Motorista>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Motorist__3214EC07F13F7ED8");

            entity.HasIndex(e => e.Cpf, "UQ__Motorist__C1F89731890B0C25").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.TipoHabilitacao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Rota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rota__3214EC078D62E860");

            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Veiculo__3214EC076FFDD8A5");

            entity.ToTable("Veiculo");

            entity.HasIndex(e => e.Placa, "UQ__Veiculo__8310F99D94849EA7").IsUnique();

            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Viagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Viagem__3214EC079BA62B9B");

            entity.ToTable("Viagem");

            entity.HasIndex(e => e.Codigo, "UQ__Viagem__06370DACDB700C87").IsUnique();

            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Motorista).WithMany(p => p.Viagems)
                .HasForeignKey(d => d.MotoristaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Viagem_Motorista");

            entity.HasOne(d => d.Rota).WithMany(p => p.Viagems)
                .HasForeignKey(d => d.RotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Viagem_Rota");

            entity.HasOne(d => d.Veiculo).WithMany(p => p.Viagems)
                .HasForeignKey(d => d.VeiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Viagem_Veiculo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
