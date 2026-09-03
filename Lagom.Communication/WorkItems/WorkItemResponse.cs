using System.ComponentModel;

namespace Lagom.Communication.WorkItems;

public class WorkItemResponse
{
    [Description("Identificador único da tarefa.")]
    public int Id { get; set; }

    [Description("Título ou nome da tarefa.")]
    public string Title { get; set; } = string.Empty;

    [Description("Data na qual a tarefa deve ser realizada.")]
    public String Date { get; set; } = string.Empty;

    [Description("Duração estimada da tarefa.")]
    public string Duration { get; set; } = string.Empty;

    [Description("Indicador da conclusão da tarefa.")]
    public bool IsCompleted { get; set; }
}
