using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class DbDesperdicioAlimentosContext : DbContext
{
    public DbDesperdicioAlimentosContext()
    {
    }

    public DbDesperdicioAlimentosContext(DbContextOptions<DbDesperdicioAlimentosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssinaturaDescarte> AssinaturaDescartes { get; set; }

    public virtual DbSet<CategoriaItem> CategoriaItems { get; set; }

    public virtual DbSet<CategoriaRecaptcha> CategoriaRecaptchas { get; set; }

    public virtual DbSet<ImagemRecaptcha> ImagemRecaptchas { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemEstoque> ItemEstoques { get; set; }

    public virtual DbSet<ItemReceitum> ItemReceita { get; set; }

    public virtual DbSet<Receitum> Receita { get; set; }

    public virtual DbSet<Restaurante> Restaurantes { get; set; }

    public virtual DbSet<TentativaRecaptcha> TentativaRecaptchas { get; set; }

    public virtual DbSet<UnidadeMedidum> UnidadeMedida { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=dbDesperdicioAlimentos;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssinaturaDescarte>(entity =>
        {
            entity.HasKey(e => e.IdDescarte).HasName("PK__Assinatu__9C9B6AC5C8CA1868");

            entity.ToTable("AssinaturaDescarte");

            entity.Property(e => e.IdDescarte).HasColumnName("idDescarte");
            entity.Property(e => e.Assinatura).HasColumnName("assinatura");
            entity.Property(e => e.FkIdItemEstoque).HasColumnName("fk_idItemEstoque");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_idUsuario");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.FkIdItemEstoqueNavigation).WithMany(p => p.AssinaturaDescartes)
                .HasForeignKey(d => d.FkIdItemEstoque)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Assinatur__fk_id__5629CD9C");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.AssinaturaDescartes)
                .HasForeignKey(d => d.FkIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Assinatur__fk_id__60A75C0F");
        });

        modelBuilder.Entity<CategoriaItem>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240CA5EF7DE0");

            entity.ToTable("CategoriaItem");

            entity.HasIndex(e => e.Nome, "UQ__Categori__6F71C0DC82289B8C").IsUnique();

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<CategoriaRecaptcha>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaRecaptcha).HasName("PK__Categori__F2BA0381DF2E5585");

            entity.ToTable("CategoriaRecaptcha");

            entity.HasIndex(e => e.Nome, "UQ__Categori__6F71C0DCDC8B2DA4").IsUnique();

            entity.Property(e => e.IdCategoriaRecaptcha).HasColumnName("idCategoriaRecaptcha");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<ImagemRecaptcha>(entity =>
        {
            entity.HasKey(e => e.IdImagemRecaptcha).HasName("PK__ImagemRe__1B233D6C43DB26EB");

            entity.ToTable("ImagemRecaptcha");

            entity.Property(e => e.IdImagemRecaptcha).HasColumnName("idImagemRecaptcha");
            entity.Property(e => e.FkIdCategoriaRecaptcha).HasColumnName("fk_idCategoriaRecaptcha");
            entity.Property(e => e.Imagem)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("imagem");

            entity.HasOne(d => d.FkIdCategoriaRecaptchaNavigation).WithMany(p => p.ImagemRecaptchas)
                .HasForeignKey(d => d.FkIdCategoriaRecaptcha)
                .HasConstraintName("FK__ImagemRec__fk_id__5812160E");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PK__Item__AD1942688DDC180D");

            entity.ToTable("Item");

            entity.HasIndex(e => e.Nome, "UQ__Item__6F71C0DCCE3A1143").IsUnique();

            entity.Property(e => e.IdItem).HasColumnName("idItem");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .HasColumnName("descricao");
            entity.Property(e => e.FkIdCategoria).HasColumnName("fk_idCategoria");
            entity.Property(e => e.Foto)
                .HasMaxLength(100)
                .HasColumnName("foto");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");

            entity.HasOne(d => d.FkIdCategoriaNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.FkIdCategoria)
                .HasConstraintName("FK__Item__fk_idCateg__412EB0B6");
        });

        modelBuilder.Entity<ItemEstoque>(entity =>
        {
            entity.HasKey(e => e.IdItemEstoque).HasName("PK__ItemEsto__270BB5A52EEAF482");

            entity.ToTable("ItemEstoque");

            entity.Property(e => e.IdItemEstoque).HasColumnName("idItemEstoque");
            entity.Property(e => e.DataValidade).HasColumnName("dataValidade");
            entity.Property(e => e.FkIdItem).HasColumnName("fk_idItem");
            entity.Property(e => e.FkIdRestaurante).HasColumnName("fk_idRestaurante");
            entity.Property(e => e.FkIdUnidade).HasColumnName("fk_idUnidade");
            entity.Property(e => e.Quantidade)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantidade");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("válido")
                .HasColumnName("status");

            entity.HasOne(d => d.FkIdItemNavigation).WithMany(p => p.ItemEstoques)
                .HasForeignKey(d => d.FkIdItem)
                .HasConstraintName("FK__ItemEstoq__fk_id__49C3F6B7");

            entity.HasOne(d => d.FkIdRestauranteNavigation).WithMany(p => p.ItemEstoques)
                .HasForeignKey(d => d.FkIdRestaurante)
                .HasConstraintName("FK__ItemEstoq__fk_id__4AB81AF0");

            entity.HasOne(d => d.FkIdUnidadeNavigation).WithMany(p => p.ItemEstoques)
                .HasForeignKey(d => d.FkIdUnidade)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__ItemEstoq__fk_id__5BE2A6F2");
        });

        modelBuilder.Entity<ItemReceitum>(entity =>
        {
            entity.HasKey(e => e.IdItemReceita).HasName("PK__ItemRece__EC6B06B51A1AE99B");

            entity.Property(e => e.IdItemReceita).HasColumnName("idItemReceita");
            entity.Property(e => e.FkIdItem).HasColumnName("fk_idItem");
            entity.Property(e => e.FkIdReceita).HasColumnName("fk_idReceita");
            entity.Property(e => e.FkIdUnidade).HasColumnName("fk_idUnidade");
            entity.Property(e => e.Quantidade)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantidade");

            entity.HasOne(d => d.FkIdItemNavigation).WithMany(p => p.ItemReceita)
                .HasForeignKey(d => d.FkIdItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemRecei__fk_id__5165187F");

            entity.HasOne(d => d.FkIdReceitaNavigation).WithMany(p => p.ItemReceita)
                .HasForeignKey(d => d.FkIdReceita)
                .HasConstraintName("FK__ItemRecei__fk_id__5CD6CB2B");

            entity.HasOne(d => d.FkIdUnidadeNavigation).WithMany(p => p.ItemReceita)
                .HasForeignKey(d => d.FkIdUnidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemRecei__fk_id__5EBF139D");
        });

        modelBuilder.Entity<Receitum>(entity =>
        {
            entity.HasKey(e => e.IdReceita).HasName("PK__Receita__B2B9B41BA6D91926");

            entity.Property(e => e.IdReceita).HasColumnName("idReceita");
            entity.Property(e => e.Foto)
                .HasMaxLength(100)
                .HasColumnName("foto");
            entity.Property(e => e.ModoPreparo).HasColumnName("modoPreparo");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.IdRestaurante).HasName("PK__Restaura__5E9CB8F21C3E4C82");

            entity.ToTable("Restaurante");

            entity.HasIndex(e => e.Nome, "UQ__Restaura__6F71C0DCBDF2B35F").IsUnique();

            entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .HasColumnName("endereco");
            entity.Property(e => e.Logotipo)
                .HasMaxLength(50)
                .HasColumnName("logotipo");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<TentativaRecaptcha>(entity =>
        {
            entity.HasKey(e => e.IdTentativa).HasName("PK__Tentativ__A2BB5385F2146FDE");

            entity.ToTable("TentativaRecaptcha");

            entity.Property(e => e.IdTentativa).HasColumnName("idTentativa");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fk_idUsuario");
            entity.Property(e => e.Resultado)
                .HasMaxLength(50)
                .HasColumnName("resultado");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.TentativaRecaptchas)
                .HasForeignKey(d => d.FkIdUsuario)
                .HasConstraintName("FK__Tentativa__fk_id__5BE2A6F2");
        });

        modelBuilder.Entity<UnidadeMedidum>(entity =>
        {
            entity.HasKey(e => e.IdUnidade).HasName("PK__UnidadeM__8075AD8DE34C42E7");

            entity.HasIndex(e => e.Nome, "UQ__UnidadeM__6F71C0DCA87EF758").IsUnique();

            entity.Property(e => e.IdUnidade).HasColumnName("idUnidade");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A68400B5F3");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Nome, "UQ__Usuario__6F71C0DC1A9553C0").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.BloqueioPin)
                .HasColumnType("datetime")
                .HasColumnName("bloqueioPIN");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FkIdRestaurante).HasColumnName("fk_idRestaurante");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Pin)
                .HasMaxLength(6)
                .HasColumnName("pin");
            entity.Property(e => e.Senha)
                .HasMaxLength(256)
                .HasColumnName("senha");
            entity.Property(e => e.TentativasPin)
                .HasDefaultValue(0, "DF__Usuario__tentati__44FF419A")
                .HasColumnName("tentativasPIN");

            entity.HasOne(d => d.FkIdRestauranteNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkIdRestaurante)
                .HasConstraintName("FK__Usuario__fk_idRe__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
