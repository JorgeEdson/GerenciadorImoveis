using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class EnderecoMapa : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.Logradouro).IsRequired();
            builder.Property(x => x.Bairro).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.UF).IsRequired();
            builder.Property(x => x.Cep).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.Imovel)
                .WithOne(x => x.Endereco)
                .HasForeignKey<Endereco>(x => x.ImovelId)
                .OnDelete(DeleteBehavior.Restrict);
           

        }
    }
}
