using AgendaApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade para Tarefa
    /// </summary>
    public class Tarefa
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public PrioridadeTarefa? Prioridade { get; set; }
        public DateTime? CadastradoEm { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }
        public bool? Ativo { get; set; }

        #endregion
    }
}
