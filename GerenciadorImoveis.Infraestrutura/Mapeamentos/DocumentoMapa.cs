using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class DocumentoMapa : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();            
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.Identificador).IsRequired();
            builder.Property(x => x.TipoDocumento).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.Cliente)
                .WithOne(x => x.Documento)
                .HasForeignKey<Documento>(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }    
}
