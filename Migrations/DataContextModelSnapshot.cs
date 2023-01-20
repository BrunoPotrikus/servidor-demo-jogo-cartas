﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServidorDemoJogoCartas.Data;

#nullable disable

namespace ServidorDemoJogoCartas.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServidorDemoJogoCartas.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Simbolo")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Simbolo");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Titulo" }, "IX_Categoria_Titulo")
                        .IsUnique();

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("ServidorDemoJogoCartas.Models.Personagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Descricao");

                    b.Property<int>("Fogo")
                        .HasColumnType("INT")
                        .HasColumnName("Fogo");

                    b.Property<int>("Forca")
                        .HasColumnType("INT")
                        .HasColumnName("Forca");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Magia")
                        .HasColumnType("INT")
                        .HasColumnName("Magia");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Personagem", (string)null);
                });

            modelBuilder.Entity("ServidorDemoJogoCartas.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Apelido");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Senha");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Sobrenome");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("UsuarioPersonagem", b =>
                {
                    b.Property<Guid>("PersonagemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonagemId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioPersonagem");
                });

            modelBuilder.Entity("ServidorDemoJogoCartas.Models.Personagem", b =>
                {
                    b.HasOne("ServidorDemoJogoCartas.Models.Categoria", "Categoria")
                        .WithMany("Personagens")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Personagem_Categoria");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("UsuarioPersonagem", b =>
                {
                    b.HasOne("ServidorDemoJogoCartas.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("PersonagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UsuarioPersonagem_PersoangemId");

                    b.HasOne("ServidorDemoJogoCartas.Models.Personagem", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UsuarioPersonagem_UsuarioId");
                });

            modelBuilder.Entity("ServidorDemoJogoCartas.Models.Categoria", b =>
                {
                    b.Navigation("Personagens");
                });
#pragma warning restore 612, 618
        }
    }
}
