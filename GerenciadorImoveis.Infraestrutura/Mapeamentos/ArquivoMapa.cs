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
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.Caminho).IsRequired();
            builder.Property(x => x.TipoArquivo).IsRequired();

            //Chaves estrangeiras

        }
    }
}
