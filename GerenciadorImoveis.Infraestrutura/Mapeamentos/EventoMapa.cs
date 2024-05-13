using GerenciadorImoveis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorImoveis.Infraestrutura.Mapeamentos
{
    public class EventoMapa : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            //campos entidade base
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.DataAtualizacao).IsRequired(false);
            builder.Property(x => x.Ativo).IsRequired();

            //campos entidade
            builder.Property(x => x.Descricao).IsRequired();

            //Chaves estrangeiras
            builder.HasOne(x => x.CadastradoPor)
            .WithMany(x => x.Eventos)
            .HasForeignKey(x => x.CadastradoPorId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
