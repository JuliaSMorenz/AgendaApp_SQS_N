using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Repositories
{
    /// <summary>
    /// Classe para implementar a interface de repositório
    /// </summary>
    public class TarefaRepository : ITarefaRepository
    {
        public void Add(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(tarefa);
                dataContext.SaveChanges();
            }
        }

        public void Update(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(tarefa);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(tarefa);
                dataContext.SaveChanges();
            }
        }

        public List<Tarefa> Get(DateTime dataMin, DateTime dataMax)
        {
            using (var dataContext = new DataContext())
            {
                //LAMBDA
                /*
                return dataContext
                    .Set<Tarefa>() //entidade
                    .Where(t => t.DataHora >= dataMin && t.DataHora <= dataMax) //filtro
                    .OrderByDescending(t => t.DataHora) //ordenação
                    .ToList(); //retornar uma lista com os resultados
                */

                //LINQ
                var query = from t in dataContext.Set<Tarefa>()
                            where t.DataHora >= dataMin && t.DataHora <= dataMax
                            orderby t.DataHora descending
                            select t;

                return query.ToList();
            }
        }

        public Tarefa? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                //LAMBDA
                /*
                return dataContext.Set<Tarefa>().Find(id);
                */

                //LINQ
                var query = from t in dataContext.Set<Tarefa>()
                            where t.Id == id
                            select t;

                return query.FirstOrDefault();
            }
        }
    }
}
