using Lagom.Application.WorkItems.UseCase;
using Lagom.Application.WorkItems.UseCase.Register;
using Lagom.Communication.Shared;
using Lagom.Communication.WorkItems;
using Lagom.Exception.Shared;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Lagom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkItemsController : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Lista todas as tarefas ou filtra por intervalo de datas")]
    [EndpointDescription("Retorna uma lista de atividades. Opcionalmente, você pode filtrar as tarefas fornecendo uma data de início e uma data de término.")]
    [ProducesResponseType<WorkItemsResponse>(StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAllWorkItemsAsync(
        [FromQuery, Description("Data inicial do filtro (inclusive). Formato: yyyy-MM-dd.")] DateOnly? startDate,
        [FromQuery, Description("Data final do filtro (inclusive). Formato: yyyy-MM-dd.")] DateOnly? endDate,
        [FromServices] ListAllWorkItemsUseCase listAllWorkItemsUseCase
    ) => Ok(await listAllWorkItemsUseCase.ExecuteAsync(startDate, endDate));

    [HttpGet("{id}")]
    [EndpointSummary("Obtém uma tarefa específica pelo ID")]
    [EndpointDescription("Retorna uma tarefa específica com base no ID fornecido.")]
    [ProducesResponseType<WorkItemResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetWorkItemAsync(
        [FromRoute, Description("Identificador único da tarefa.")] int id,
        [FromServices] FindWorkItemByIdUseCase findWorkItemByIdUseCase
    )
    {
        var workItem = await findWorkItemByIdUseCase.ExecuteAsync(id);
        if (workItem == null)
        {
            return NotFound();
        }

        return Ok(workItem);
    }

    [HttpPost]
    [EndpointSummary("Cria uma nova tarefa")]
    [EndpointDescription("Cria uma nova tarefa com base nos dados fornecidos.")]
    [ProducesResponseType<WorkItemResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateWorkItemAsync(
        [FromBody, Description("Objeto contendo os detalhes da nova tarefa.")] RegisterWorkItemRequest newWorkItem,
        [FromServices] RegisterNewWorkItemUseCase registerNewWorkItemUseCase
    )
    {
        try
        {
            return Created(string.Empty, await registerNewWorkItemUseCase.ExecuteAsync(newWorkItem));
        }
        catch (ErrorOnValidationException ex)
        {
            return BadRequest(
                new ResponseErrors(ex.Errors)
            );
        }
        catch
        {
            var errors = new ResponseErrors("Erro desconhecido");

            return StatusCode(StatusCodes.Status500InternalServerError, errors);
        }
    }
}
