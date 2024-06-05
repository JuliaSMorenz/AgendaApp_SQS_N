using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Tarefa.
    /// </summary>
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            //chave primária
            builder.HasKey(t => t.Id);

            //mapeamento dos campos
            builder.Property(t => t.Nome).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Descricao).HasMaxLength(250).IsRequired();
            builder.Property(t => t.DataHora).IsRequired();
            builder.Property(t => t.Prioridade).IsRequired();
            builder.Property(t => t.CadastradoEm).IsRequired();
            builder.Property(t => t.UltimaAtualizacaoEm).IsRequired();
            builder.Property(t => t.Ativo).IsRequired();
        }
    }
}
