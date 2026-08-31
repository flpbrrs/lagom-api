using System.ComponentModel;

namespace Lagom.Communication.Tasks;

public class RegisterTaskRequest
{
    [Description("Título da tarefa.")]
    public string Title { get; set; } = string.Empty;

    [Description("Duração da tarefa em minutos.")]
    public int DurationInMinutes { get; set; }

    [Description("Data da tarefa deve ser realizada.")]
    public DateOnly Date { get; set; }
}
