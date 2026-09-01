using Lagom.API.Domain.Models;
using Lagom.Application.Tasks.UseCase;
using Lagom.Communication.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Lagom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private int nextId = 4;
    private static readonly List<WorkTask> Tasks =
        [
            new() { Id = 1, Title = "Task 1", DurationInMinutes = 60, IsCompleted = false },
            new() { Id = 2, Title = "Task 2", Date = new DateOnly(2026, 8, 20), DurationInMinutes = 120, IsCompleted = true },
            new() { Id = 3, Title = "Task 3", Date = new DateOnly(2026, 8, 25), DurationInMinutes = 30, IsCompleted = false }
        ];

    [HttpGet]
    [EndpointSummary("Lista todas as tarefas ou filtra por intervalo de datas")]
    [EndpointDescription("Retorna uma lista de atividades. Opcionalmente, você pode filtrar as tarefas fornecendo uma data de início e uma data de término.")]
    [ProducesResponseType<List<TaskResponse>>(StatusCodes.Status200OK)]
    public IActionResult ListAllTasks(
        [FromQuery, Description("Data inicial do filtro (inclusive). Formato: yyyy-MM-dd.")] DateOnly? startDate,
        [FromQuery, Description("Data final do filtro (inclusive). Formato: yyyy-MM-dd.")] DateOnly? endDate,
        [FromServices] ListAllTasksUseCase listAllTasksUseCase
    ) => Ok(listAllTasksUseCase.Execute(startDate, endDate));

    [HttpGet("{id}")]
    [EndpointSummary("Obtém uma tarefa específica pelo ID")]
    [EndpointDescription("Retorna uma tarefa específica com base no ID fornecido.")]
    [ProducesResponseType<TaskResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTask([FromRoute, Description("Identificador único da tarefa.")] int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        // TODO: Mover essa lógica de mapeamento para um serviço ou método separado para manter o controller limpo.
        var response = new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Date = task.Date.ToString("dd/MM/yyyy"),
            Duration = TimeSpan.FromMinutes(task.DurationInMinutes).ToString(@"hh\hmm"),
            IsCompleted = task.IsCompleted
        };

        return Ok(response);
    }

    [HttpPost]
    [EndpointSummary("Cria uma nova tarefa")]
    [EndpointDescription("Cria uma nova tarefa com base nos dados fornecidos.")]
    [ProducesResponseType<TaskResponse>(StatusCodes.Status201Created)]
    public IActionResult CreateTask(
        [FromBody, Description("Objeto contendo os detalhes da nova tarefa.")] RegisterTaskRequest newTask,
        [FromServices] RegisterNewTaskUseCase registerNewTaskUseCase
    ) => Created(string.Empty, registerNewTaskUseCase.Execute(newTask));
}

