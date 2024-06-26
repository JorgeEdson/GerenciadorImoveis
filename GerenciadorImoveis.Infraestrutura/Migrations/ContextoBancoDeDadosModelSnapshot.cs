﻿// <auto-generated />
using System;
using GerenciadorImoveis.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciadorImoveis.Infraestrutura.Migrations
{
    [DbContext(typeof(ContextoBancoDeDados))]
    partial class ContextoBancoDeDadosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Arquivo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoArquivo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<long?>("DocumentoId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Documento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<long?>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Identificador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique()
                        .HasFilter("[ClienteId] IS NOT NULL");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ImovelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImovelId")
                        .IsUnique()
                        .HasFilter("[ImovelId] IS NOT NULL");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Evento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ArquivoId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<long?>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataOcorrencia")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DocumentoId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ImovelId")
                        .HasColumnType("bigint");

                    b.Property<long?>("MatriculaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PlantaId")
                        .HasColumnType("bigint");

                    b.Property<int>("TipoEvento")
                        .HasColumnType("int");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArquivoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("ImovelId");

                    b.HasIndex("MatriculaId");

                    b.HasIndex("PlantaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Imovel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal?>("AreaEdificacao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AreaTerreno")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAquisicao")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<int>("ImovelStatus")
                        .HasColumnType("int");

                    b.Property<long?>("MatriculaId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PlantaId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProprietarioId")
                        .HasColumnType("bigint");

                    b.Property<int>("TipoImovel")
                        .HasColumnType("int");

                    b.Property<long>("TipoImovelId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ValorAquisicao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Matricula", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ArquivoId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<long?>("ImovelId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArquivoId");

                    b.HasIndex("ImovelId")
                        .IsUnique()
                        .HasFilter("[ImovelId] IS NOT NULL");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Planta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ArquivoId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<long?>("ImovelId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArquivoId");

                    b.HasIndex("ImovelId")
                        .IsUnique()
                        .HasFilter("[ImovelId] IS NOT NULL");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Ativo = true,
                            NomeUsuario = "UsuarioMaster",
                            Senha = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9",
                            TipoUsuario = 0
                        });
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Endereco", "Endereco")
                        .WithMany("Clientes")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Documento", b =>
                {
                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Cliente", "Cliente")
                        .WithOne("Documento")
                        .HasForeignKey("GerenciadorImoveis.Dominio.Entidades.Documento", "ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Endereco", b =>
                {
                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Imovel", "Imovel")
                        .WithOne("Endereco")
                        .HasForeignKey("GerenciadorImoveis.Dominio.Entidades.Endereco", "ImovelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Evento", b =>
                {
                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Arquivo", "Arquivo")
                        .WithMany("Eventos")
                        .HasForeignKey("ArquivoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany("Eventos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Documento", null)
                        .WithMany("Eventos")
                        .HasForeignKey("DocumentoId");

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Endereco", "Endereco")
                        .WithMany("Eventos")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Imovel", "Imovel")
                        .WithMany("Eventos")
                        .HasForeignKey("ImovelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Matricula", "Matricula")
                        .WithMany("Eventos")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Planta", "Planta")
                        .WithMany("Eventos")
                        .HasForeignKey("PlantaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Usuario", "UsuarioAcao")
                        .WithMany("Eventos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Arquivo");

                    b.Navigation("Cliente");

                    b.Navigation("Endereco");

                    b.Navigation("Imovel");

                    b.Navigation("Matricula");

                    b.Navigation("Planta");

                    b.Navigation("UsuarioAcao");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Imovel", b =>
                {
                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Cliente", "Proprietario")
                        .WithMany("Imoveis")
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Matricula", b =>
                {
                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Arquivo", "Arquivo")
                        .WithMany()
                        .HasForeignKey("ArquivoId");

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Imovel", "Imovel")
                        .WithOne("Matricula")
                        .HasForeignKey("GerenciadorImoveis.Dominio.Entidades.Matricula", "ImovelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Arquivo");

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Planta", b =>
                {
                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Arquivo", "Arquivo")
                        .WithMany()
                        .HasForeignKey("ArquivoId");

                    b.HasOne("GerenciadorImoveis.Dominio.Entidades.Imovel", "Imovel")
                        .WithOne("Planta")
                        .HasForeignKey("GerenciadorImoveis.Dominio.Entidades.Planta", "ImovelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Arquivo");

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Arquivo", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Documento");

                    b.Navigation("Eventos");

                    b.Navigation("Imoveis");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Documento", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Endereco", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Imovel", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Eventos");

                    b.Navigation("Matricula");

                    b.Navigation("Planta");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Matricula", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Planta", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("GerenciadorImoveis.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
