using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class MatriculaMapa : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.DataAtualizacao).IsRequired(false);
            builder.Property(x => x.Ativo).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.Imovel)
                .WithOne(x => x.Matricula)
                .HasForeignKey<Matricula>(x => x.ImovelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CadastradoPor)
                .WithMany(x => x.MatriculasCadastradas)
                .HasForeignKey(x => x.CadastradoPorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AtualizadoPor)
                .WithMany(x => x.MatriculasAlteradas)
                .HasForeignKey(x => x.AtualizadoPorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }    
}
