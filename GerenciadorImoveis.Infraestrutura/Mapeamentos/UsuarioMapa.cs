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
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.DataAtualizacao).IsRequired(false);
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.NomeCompleto).IsRequired(false);
            builder.Property(x => x.NomeUsuario).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.TipoUsuario).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.CadastradoPor)
            .WithMany(x => x.UsuariosCadastrados)
            .HasForeignKey(x => x.CadastradoPorId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AtualizadoPor)
            .WithMany(x => x.UsuariosAlterados)
            .HasForeignKey(x => x.AtualizadoPorId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
