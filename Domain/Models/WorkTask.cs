using System.ComponentModel;

namespace Lagom.Domain.Models;

[Description("Representa uma tarefa a ser executada.")]
public class WorkTask
{
    [Description("Identificador único da tarefa.")]
    public int Id { get; set; }

    [Description("Título da tarefa.")]
    public required string Title { get; set; }

    [Description("Data em que a tarefa está agendada.")]
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    [Description("Duração estimada da tarefa, em minutos.")]
    public int DurationInMinutes { get; set; } = 0;

    [Description("Indica se a tarefa já foi concluída.")]
    public bool IsCompleted { get; set; } = false;
}
