using Lagom.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Lagom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly List<WorkTask> tasks =
        [
            new() { Id = 1, Title = "Task 1", DurationInMinutes = 60, IsCompleted = false },
            new() { Id = 2, Title = "Task 2", Date = new DateOnly(2026, 8, 20), DurationInMinutes = 120, IsCompleted = true },
            new() { Id = 3, Title = "Task 3", Date = new DateOnly(2026, 8, 25), DurationInMinutes = 30, IsCompleted = false }
        ];

    [HttpGet]
    [EndpointSummary("Lista todas as tarefas ou filtra por intervalo de datas")]
    [EndpointDescription(" Retorna uma lista de atividades. Opcionalmente, você pode filtrar as tarefas fornecendo uma data de início e uma data de término.")]
    [ProducesResponseType<List<WorkTask>>(StatusCodes.Status200OK)]
    public IActionResult GetTasks(
        [FromQuery, Description("Data inicial do filtro (inclusive). Formato: yyyy-MM-dd.")] DateOnly? startDate,
        [FromQuery, Description("Data final do filtro (inclusive). Formato: yyyy-MM-dd.")] DateOnly? endDate
    )
    {
        if(startDate.HasValue && endDate.HasValue)
        {
            return Ok(tasks.Where(t => t.Date >= startDate.Value && t.Date <= endDate.Value));
        }

        return Ok(tasks);
    }

    [HttpGet("/{id}")]
    [EndpointSummary("Obtém uma tarefa específica pelo ID")]
    [EndpointDescription("Retorna uma tarefa específica com base no ID fornecido.")]
    [ProducesResponseType<WorkTask>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTask([FromRoute, Description("Identificador único da tarefa.")] double id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }
}

