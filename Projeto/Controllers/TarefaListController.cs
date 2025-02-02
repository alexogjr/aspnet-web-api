using Microsoft.AspNetCore.Mvc;
using Projeto.Models;

namespace Projeto.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TarefaListController : ControllerBase
    {

        private static List<Models.tarefaList> _tarefas = new()
        {
            new Models.tarefaList { TarefaId = 1, NomeTarefa = "Fazer compras", DescricaoTarefa = "Macarr�o", Date = DateOnly.FromDateTime(DateTime.Now) },
            new Models.tarefaList { TarefaId = 2, NomeTarefa = "Estudar C#", DescricaoTarefa = "WebAPI", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)) }
        };

        // busca todas as tarefas
        [HttpGet]
        public IEnumerable<Models.tarefaList> Get()
        {
            return _tarefas;
        }

        // busca todas a tarefa pelo id
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var tarefaExistente = _tarefas.FirstOrDefault(t => t.TarefaId == id);

            if (tarefaExistente == null)
            {
                return NotFound();
            }

            return Ok(tarefaExistente);
        }

        // cria uma nova tarefa via post
        [HttpPost("{id}")]
        public IActionResult Post(int id, Models.tarefaList novaTarefa)
        {

            // armazena na vari�vel o primeiro que atende �s condi��es
            var tarefaExistente = _tarefas.FirstOrDefault(t => t.TarefaId == id);

            // se for diferente de null, ent�o existe
            if (tarefaExistente != null)
            {
                return Conflict(tarefaExistente);
            }
            
            _tarefas.Add(novaTarefa);
            return Ok(novaTarefa);
        }

        // atualiza uma tarefa via id
        [HttpPut("{id}", Name = "UpdateTarefa")]
        public IActionResult Put(int id, Models.tarefaList tarefaAtualizada)
        {

            // armazena na vari�vel o primeiro que atende �s condi��es
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound("Tarefa n�o encontrada");
            }

            tarefa.NomeTarefa = tarefaAtualizada.NomeTarefa;
            tarefa.DescricaoTarefa = tarefaAtualizada.DescricaoTarefa;
            tarefa.TarefaId = tarefaAtualizada.TarefaId;
            tarefa.Date = tarefaAtualizada.Date;

            return Ok(_tarefas);
        }

        // deletar tarefas via id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound("Tarefa n�o encontrada");
            }
            
            _tarefas.Remove(tarefa);
            return Ok(_tarefas);
        }
    }
}