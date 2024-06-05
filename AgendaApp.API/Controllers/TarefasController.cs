using AgendaApp.API.Models;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Entities.Enums;
using AgendaApp.Domain.Exceptions;
using AgendaApp.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        //atributos
        private readonly ITarefaDomainService _tarefaDomainService;
        private readonly IMapper _mapper;

        //construtor para injeção de dependências das interfaces
        public TarefasController(ITarefaDomainService tarefaDomainService, IMapper mapper)
        {
            _tarefaDomainService = tarefaDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 201)]
        public IActionResult Post(TarefasPostRequestModel model)
        {
            try
            {
                //salvando a tarefa no dominio
                var tarefa = _tarefaDomainService.Adicionar(_mapper.Map<Tarefa>(model));

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
                return StatusCode(201, response);
            }
            catch(DomainException e)
            {
                //HTTP 422 (UNPROCESSABLE CONTENT)
                return StatusCode(422, new { message = e.Message });
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Put(TarefasPutRequestModel model)
        {
            try
            {
                //atualizar a tarefa
                var tarefa = _tarefaDomainService.Atualizar(_mapper.Map<Tarefa>(model));

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
                return StatusCode(200, response);
            }
            catch (DomainException e)
            {
                //HTTP 422 (UNPROCESSABLE CONTENT)
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //excluir a tarefa
                var tarefa = _tarefaDomainService.Excluir(id);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
                return StatusCode(200, response);
            }
            catch (DomainException e)
            {
                //HTTP 422 (UNPROCESSABLE CONTENT)
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{dataMin}/{dataMax}")]
        [ProducesResponseType(typeof(List<TarefasGetResponseModel>), 200)]
        public IActionResult Get(DateTime dataMin, DateTime dataMax)
        {
            try
            {
                //consultar as tarefas dentro do periodo de datas
                var tarefas = _tarefaDomainService.Consultar(dataMin, dataMax);

                //verificar se nenhuma tarefa foi encontrada
                if (!tarefas.Any())
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<List<TarefasGetResponseModel>>(tarefas);
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TarefasGetResponseModel), 200)]
        public IActionResult Get(Guid id)
        {
            try
            {
                //consultar 1 tarefa baseado no ID
                var tarefa = _tarefaDomainService.ObterPorId(id);

                //verificar se a tarefa não foi encontrada
                if (tarefa == null)
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
