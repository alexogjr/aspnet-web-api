namespace Projeto.Models
{
    public class tarefaList
    {
        public DateOnly Date { get; set; }

        public string NomeTarefa { get; set; } = string.Empty;

        public string DescricaoTarefa { get; set; } = string.Empty;

        public int TarefaId { get; set; }
    }
}
