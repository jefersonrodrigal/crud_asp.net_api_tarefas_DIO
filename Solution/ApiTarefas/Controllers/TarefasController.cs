using System.Net;
using ApiTarefas.DataBase;
using ApiTarefas.DTO;
using ApiTarefas.Models;
using ApiTarefas.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [ApiController]
    [Route("/tarefas")]
    public class TarefasController : ControllerBase
    {

        private ApiDbContext context = new ApiDbContext();

        [HttpPost]
        public IActionResult Create([FromBody] TarefaDto tarefaDto)
        {

            var tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                Concluido = tarefaDto.Concluido

            };

            context.Tarefa.Add(tarefa);
            context.SaveChanges();
            return StatusCode(201, new ViewTarefa{Message="Tarefa cadastrada com sucesso"});
        }

        [HttpGet]
        public IActionResult Read()
        {
            var tarefas = context.Tarefa.ToList();
            return StatusCode(200, tarefas);
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TarefaDto dtotarefa)
        {
            var tarefa = context.Tarefa.Find(id);

            if(tarefa == null)
            {
                return StatusCode(404);
            }


            tarefa.Titulo = dtotarefa.Titulo;
            tarefa.Descricao = dtotarefa.Descricao;
            tarefa.Concluido = dtotarefa.Concluido;

            context.Tarefa.Update(tarefa);
            context.SaveChanges();

            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var tarefaData = context.Tarefa.Find(id);

            if(tarefaData == null)
            {
                return StatusCode(404);
            }

            context.Tarefa.Remove(tarefaData);
            context.SaveChanges();

            return StatusCode(200);
        }
    }
}