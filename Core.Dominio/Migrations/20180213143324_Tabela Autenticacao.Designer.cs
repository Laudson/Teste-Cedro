﻿// <auto-generated />
using Core.Dominio.Comum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Core.Dominio.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20180213143324_Tabela Autenticacao")]
    partial class TabelaAutenticacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Comum.Comum.AutenticacaoDTO", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Codigo");

                    b.ToTable("Autenticaao");
                });

            modelBuilder.Entity("Core.Comum.Comum.PratosDTO", b =>
                {
                    b.Property<int>("IdPratos")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdRestaurante");

                    b.Property<string>("NomePrato")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("IdPratos");

                    b.HasIndex("IdRestaurante");

                    b.ToTable("Pratos");
                });

            modelBuilder.Entity("Core.Comum.Comum.RestauranteDTO", b =>
                {
                    b.Property<int>("IdRestaurante")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeRestaurante")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("IdRestaurante");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("Core.Comum.Comum.PratosDTO", b =>
                {
                    b.HasOne("Core.Comum.Comum.RestauranteDTO")
                        .WithMany("Pratos")
                        .HasForeignKey("IdRestaurante")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
