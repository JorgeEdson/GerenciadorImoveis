using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class PlantaMapa : IEntityTypeConfiguration<Planta>
    {
        public void Configure(EntityTypeBuilder<Planta> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ativo).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.Imovel)
                .WithOne(x => x.Planta)
                .HasForeignKey<Planta>(x => x.ImovelId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
