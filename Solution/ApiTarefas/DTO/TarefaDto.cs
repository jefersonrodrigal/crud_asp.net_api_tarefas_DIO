
namespace ApiTarefas.DTO
{
    public record TarefaDto
    {
        public string Titulo {get; set;}
        public string Descricao {get; set;}
        public bool Concluido {get; set;}
    }
}