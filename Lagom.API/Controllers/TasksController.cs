using Lagom.Application.Tasks.UseCase;
using Lagom.Communication.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Lagom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
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
    public IActionResult GetTask(
        [FromRoute, Description("Identificador único da tarefa.")] int id,
        [FromServices] FindTaskByIdUseCase findTaskByIdUseCase
    )
    {
        var task = findTaskByIdUseCase.Execute(id);
        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
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