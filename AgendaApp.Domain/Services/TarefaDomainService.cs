using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Exceptions;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de domínio para tarefa
    /// </summary>
    public class TarefaDomainService : ITarefaDomainService
    {
        //atributos
        private readonly ITarefaRepository _tarefaRepository;

        //método construtor para injeção de dependência da interface ITarefaRepository
        public TarefaDomainService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public Tarefa Adicionar(Tarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            tarefa.CadastradoEm = DateTime.Now;
            tarefa.UltimaAtualizacaoEm = DateTime.Now;
            tarefa.Ativo = true;

            _tarefaRepository.Add(tarefa);

            return tarefa;
        }

        public Tarefa Atualizar(Tarefa tarefa)
        {
            #region Buscar a tarefa no banco de dados através do ID

            var tarefaEdicao = _tarefaRepository.GetById(tarefa.Id.Value);
            DomainException.When(tarefaEdicao == null, 
                "A tarefa é inválida para edição. Verifique o ID informado.");

            #endregion

            #region Alterar os dados da tarefa

            tarefaEdicao.Nome = tarefa.Nome;
            tarefaEdicao.Descricao = tarefa.Descricao;
            tarefaEdicao.DataHora = tarefa.DataHora;
            tarefaEdicao.Prioridade = tarefa.Prioridade;
            tarefaEdicao.UltimaAtualizacaoEm = DateTime.Now;

            _tarefaRepository.Update(tarefaEdicao);

            return tarefaEdicao;

            #endregion            
        }

        public Tarefa Excluir(Guid id)
        {
            #region Buscar a tarefa no banco de dados através do ID

            var tarefaExclusao = _tarefaRepository.GetById(id);
            DomainException.When(tarefaExclusao == null,
                "A tarefa é inválida para exclusão. Verifique o ID informado.");

            #endregion

            #region Excluir a tarefa

            _tarefaRepository.Delete(tarefaExclusao);

            return tarefaExclusao;

            #endregion
        }

        public List<Tarefa> Consultar(DateTime dataMin, DateTime dataMax)
        {
            return _tarefaRepository.Get(dataMin, dataMax);
        }

        public Tarefa? ObterPorId(Guid id)
        {
            return _tarefaRepository.GetById(id);
        }
    }
}
