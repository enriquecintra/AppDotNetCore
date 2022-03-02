using Microsoft.EntityFrameworkCore;
using Npgsql;
using OPPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OPPI.Data
{
    public class OppiContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Provedor> Provedor { get; set; }
        public DbSet<UsuarioProvedor> UsuarioProvedor { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Navegacao> Navegacao { get; set; }

        public DbSet<Loja> Loja { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<PlanoPreco> PlanoPreco { get; set; }
        public DbSet<LojaPlanoPreco> LojaPlanoPreco { get; set; }

        public DbSet<LojaFoto> LojaFoto { get; set; }
        public DbSet<ProdutoFoto> ProdutoFoto { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }
        public DbSet<Campanha> Campanha { get; set; }


        public OppiContext(DbContextOptions<OppiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoPromocao>()
                .HasOne<Produto>(sc => sc.Produto)
                .WithMany(s => s.ProdutoPromocoes)
                .HasForeignKey(sc => sc.ProdutoId);


            modelBuilder.Entity<ProdutoPromocao>()
                .HasOne<Promocao>(sc => sc.Promocao)
                .WithMany(s => s.ProdutoPromocoes)
                .HasForeignKey(sc => sc.PromocaoId);


            modelBuilder.Entity<UsuarioProvedor>()
                .HasOne<Usuario>(sc => sc.Usuario)
                .WithMany(s => s.UsuarioProvedores)
                .HasForeignKey(sc => sc.UsuarioId);

            modelBuilder.Entity<UsuarioProvedor>()
                .HasOne<Provedor>(sc => sc.Provedor)
                .WithMany(s => s.UsuarioProvedores)
                .HasForeignKey(sc => sc.ProvedorId);



            modelBuilder.Entity<LojaFoto>()
                .HasOne<Loja>(sc => sc.Loja)
                .WithMany(s => s.LojaFotos)
                .HasForeignKey(sc => sc.LojaId);
            modelBuilder.Entity<LojaFoto>()
                .HasOne<Foto>(sc => sc.Foto)
                .WithMany(s => s.LojaFotos)
                .HasForeignKey(sc => sc.FotoId);

            modelBuilder.Entity<ProdutoFoto>()
                .HasOne<Produto>(sc => sc.Produto)
                .WithMany(s => s.ProdutoFotos)
                .HasForeignKey(sc => sc.ProdutoId);
            modelBuilder.Entity<ProdutoFoto>()
                .HasOne<Foto>(sc => sc.Foto)
                .WithMany(s => s.ProdutoFotos)
                .HasForeignKey(sc => sc.FotoId);

            modelBuilder.Entity<LojaPlanoPreco>()
                .HasOne<Loja>(sc => sc.Loja)
                .WithMany(s => s.LojaPlanoPrecos)
                .HasForeignKey(sc => sc.LojaId);
            modelBuilder.Entity<LojaPlanoPreco>()
                .HasOne<PlanoPreco>(sc => sc.PlanoPreco)
                .WithMany(s => s.LojaPlanoPrecos)
                .HasForeignKey(sc => sc.PlanoPrecoId);


            modelBuilder.Entity<LojaCampanha>()
                .HasOne<Loja>(sc => sc.Loja)
                .WithMany(s => s.LojaCampanhas)
                .HasForeignKey(sc => sc.LojaId);
            modelBuilder.Entity<LojaCampanha>()
                .HasOne<Campanha>(sc => sc.Campanha)
                .WithMany(s => s.LojaCampanhas)
                .HasForeignKey(sc => sc.CampanhaId);

            modelBuilder.Entity<CampanhaFoto>()
                .HasOne<Campanha>(sc => sc.Campanha)
                .WithMany(s => s.CampanhaFotos)
                .HasForeignKey(sc => sc.CampanhaId);
            modelBuilder.Entity<CampanhaFoto>()
                .HasOne<Foto>(sc => sc.Foto)
                .WithMany(s => s.CampanhaFotos)
                .HasForeignKey(sc => sc.FotoId);

            modelBuilder.Entity<AnuncioFoto>()
                 .HasOne<Anuncio>(sc => sc.Anuncio)
                 .WithMany(s => s.AnuncioFotos)
                 .HasForeignKey(sc => sc.AnuncioId);
            modelBuilder.Entity<AnuncioFoto>()
                .HasOne<Foto>(sc => sc.Foto)
                .WithMany(s => s.AnuncioFotos)
                .HasForeignKey(sc => sc.FotoId);



            modelBuilder.Entity<Loja>().Ignore(sc => sc.QuantidadeAvaliacoes);
            modelBuilder.Entity<Loja>().Ignore(sc => sc.MediaAvaliacoes);
            modelBuilder.Entity<Loja>().Ignore(sc => sc.Latitude);
            modelBuilder.Entity<Loja>().Ignore(sc => sc.Longitude);
            modelBuilder.Entity<Loja>().Ignore(sc => sc.Distancia);

        }
    }
}
