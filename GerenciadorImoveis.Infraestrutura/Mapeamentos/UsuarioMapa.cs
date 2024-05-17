using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class UsuarioMapa : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();            
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.NomeCompleto).IsRequired(false);
            builder.Property(x => x.NomeUsuario).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.TipoUsuario).IsRequired();

            //Chaves estrangeiras
            

        }
    }
}
