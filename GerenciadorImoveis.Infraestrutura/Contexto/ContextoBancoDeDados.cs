using GerenciadorImoveis.Dominio.Ajudantes;
using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Enumeradores;
using GerenciadorImoveis.Infraestrutura.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorImoveis.Infraestrutura.Contexto
{
    public class ContextoBancoDeDados : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }        
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }        
        public DbSet<Evento> Eventos { get; set; }
        
        
        public ContextoBancoDeDados(DbContextOptions<ContextoBancoDeDados> options) : base(options)
        {
        }
        public ContextoBancoDeDados()
        {                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseSqlServer("Data Source=GALAXYDEV\\SQLEXPRESS;Initial Catalog=GerenciadorImoveis;Integrated Security=True; TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoBancoDeDados).Assembly);
            modelBuilder.ApplyConfiguration(new ArquivoMapa());
            modelBuilder.ApplyConfiguration(new UsuarioMapa());
            modelBuilder.ApplyConfiguration(new ClienteMapa());
            modelBuilder.ApplyConfiguration(new DocumentoMapa());
            modelBuilder.ApplyConfiguration(new ImovelMapa());            
            modelBuilder.ApplyConfiguration(new EnderecoMapa());
            modelBuilder.ApplyConfiguration(new PlantaMapa());
            modelBuilder.ApplyConfiguration(new MatriculaMapa());
            modelBuilder.ApplyConfiguration(new EventoMapa());

            var superUsuario = new Usuario
                (
                    "UsuarioMaster",
                    Encriptacao.AdicionarCriptografia("admin123"),
                    TipoUsuario.ADMINISTRADOR
                );
            superUsuario.Id = 1;
            modelBuilder.Entity<Usuario>().HasData(superUsuario);
            /*
            var documentoTeste = new Documento("123456789", TipoDocumento.CPF);
            documentoTeste.Id = 1;

            var enderecoTeste = new Endereco("Rua 1", "Bairro 1", "Cidade 1", UF.CE, "12345678");
            enderecoTeste.Id = 1;

            var clienteTeste = new Cliente
                (
                    "Cliente 1",
                    "Brasileiro",
                    "Desenvolvedor",
                    documentoTeste,
                    enderecoTeste
                );
            clienteTeste.Id = 1;

            
            modelBuilder.Entity<Documento>().HasData(documentoTeste);
            modelBuilder.Entity<Endereco>().HasData(enderecoTeste);
            modelBuilder.Entity<Cliente>().HasData(clienteTeste);*/
        }
    }
}
