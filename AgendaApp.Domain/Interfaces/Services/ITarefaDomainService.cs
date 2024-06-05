using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para serviços de domínio de tarefa.
    /// </summary>
    public interface ITarefaDomainService
    {
        Tarefa Adicionar(Tarefa tarefa);
        Tarefa Atualizar(Tarefa tarefa);
        Tarefa Excluir(Guid id);

        List<Tarefa> Consultar(DateTime dataMin, DateTime dataMax);
        Tarefa? ObterPorId(Guid id);
    }
}
