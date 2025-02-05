using System.Reflection;

namespace Projeto.Data
{
    public class TarefaData
    {

        public static readonly List<Projeto.Models.tarefaList> _tarefas = new()
        {
            new Projeto.Models.tarefaList { TarefaId = 1, NomeTarefa = "Fazer compras", DescricaoTarefa = "Macarrão", Date = DateOnly.FromDateTime(DateTime.Now) },
            new Projeto.Models.tarefaList { TarefaId = 2, NomeTarefa = "Estudar C#", DescricaoTarefa = "WebAPI", Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)) }
        };

    }
}
