using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class EventoMapa : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.Mensagem).IsRequired();
            builder.Property(x => x.DataOcorrencia).IsRequired();
            builder.Property(x => x.TipoEvento).IsRequired();


            //Chaves estrangeiras
            builder.HasOne(x => x.UsuarioAcao)
            .WithMany(x => x.Eventos)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Cliente)
            .WithMany(x => x.Eventos)
            .HasForeignKey(x => x.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Endereco)
            .WithMany(x => x.Eventos)
            .HasForeignKey(x => x.EnderecoId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Imovel)
            .WithMany(x => x.Eventos)
            .HasForeignKey(x => x.ImovelId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Arquivo)
            .WithMany(x => x.Eventos)
            .HasForeignKey(x => x.ArquivoId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Matricula)
          .WithMany(x => x.Eventos)
          .HasForeignKey(x => x.MatriculaId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Planta)
          .WithMany(x => x.Eventos)
          .HasForeignKey(x => x.PlantaId)
          .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
