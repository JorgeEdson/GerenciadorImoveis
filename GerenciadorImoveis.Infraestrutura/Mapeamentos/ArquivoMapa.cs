using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class ArquivoMapa : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.DataAtualizacao).IsRequired(false);
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.Caminho).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.CadastradoPor)
           .WithMany(x => x.ArquivosCadastrados)
           .HasForeignKey(x => x.CadastradoPorId)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AtualizadoPor)
            .WithMany(x => x.ArquivosAlterados)
            .HasForeignKey(x => x.AtualizadoPorId)
            .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}
