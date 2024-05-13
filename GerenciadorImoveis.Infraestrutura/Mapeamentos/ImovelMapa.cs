using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class ImovelMapa : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.DataAtualizacao).IsRequired(false);
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.AreaTerreno).IsRequired();
            builder.Property(x => x.AreaEdificacao).IsRequired(false);
            builder.Property(x => x.ValorAquisicao).IsRequired();
            builder.Property(x => x.DataAquisicao).IsRequired();
            builder.Property(x => x.ImovelStatus).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.Endereco)
           .WithOne(x => x.Imovel)
           .HasForeignKey<Imovel>(x => x.EnderecoId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Proprietario)
           .WithMany(x => x.Imoveis)
           .HasForeignKey(x => x.EnderecoId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Matricula)
                .WithOne(x => x.Imovel)
                .HasForeignKey<Imovel>(x => x.MatriculaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Planta)
                .WithOne(x => x.Imovel)
                .HasForeignKey<Imovel>(x => x.MatriculaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CadastradoPor)
         .WithMany(x => x.ImoveisCadastrados)
         .HasForeignKey(x => x.CadastradoPorId)
         .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AtualizadoPor)
            .WithMany(x => x.ImoveisAlterados)
            .HasForeignKey(x => x.AtualizadoPorId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
