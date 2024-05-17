using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class ClienteMapa : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
           //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Nacionalidade).IsRequired();
            builder.Property(x => x.Profissao).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.Documento)
                .WithOne(x => x.Cliente)
                .HasForeignKey<Cliente>(x => x.DocumentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Endereco)
            .WithMany(x => x.Clientes)
            .HasForeignKey(x => x.EnderecoId)
            .OnDelete(DeleteBehavior.Restrict);

            


        }
    }
}
