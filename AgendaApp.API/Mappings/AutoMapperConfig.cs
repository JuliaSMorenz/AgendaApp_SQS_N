using AgendaApp.API.Models;
using AgendaApp.Domain.Entities;
using AutoMapper;

namespace AgendaApp.API.Mappings
{
    /// <summary>
    /// Mapeamento das transferencias de dados realizados pelo AutoMapper
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        //método construtor -> [ctor] + [tab]
        public AutoMapperConfig()
        {
            CreateMap<TarefasPostRequestModel, Tarefa>();
            CreateMap<TarefasPutRequestModel, Tarefa>();
            CreateMap<Tarefa, TarefasGetResponseModel>();
        }
    }
}
