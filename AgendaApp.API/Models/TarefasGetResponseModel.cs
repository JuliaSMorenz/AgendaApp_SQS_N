namespace AgendaApp.API.Models
{
    /// <summary>
    /// Modelo de dados para a resposta de consulta de tarefa
    /// </summary>
    public class TarefasGetResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Prioridade { get; set; }
        public DateTime? CadastradoEm { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }
    }
}
