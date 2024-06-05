using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para definir os métodos abstratos do repositório de tarefa.
    /// </summary>
    public interface ITarefaRepository
    {
        void Add(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Tarefa tarefa);

        List<Tarefa> Get(DateTime dataMin, DateTime dataMax);
        Tarefa? GetById(Guid id);
    }
}
