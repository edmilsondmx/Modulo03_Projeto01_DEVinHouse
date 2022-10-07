using Microsoft.AspNetCore.Mvc;
using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StatesController : ControllerBase
{
    private readonly IStateService _stateService;
    public StatesController(IStateService stateService)
    {
        _stateService = stateService;
    }

    /// <summary>
    /// Insere uma cidade ao estado
    /// </summary>
    /// <param name="stateId"> Id do estado à ser inserida a cidade</param>
    /// <param name="cityDTO"> Preencha a cidade à ser inserida</param>
    /// <response code="201">Registro criado.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Estado não encontrado</response>
    [HttpPost("{stateId}/city")]
    public IActionResult PostCity(
        [FromRoute] int stateId,
        [FromBody] CityDTO cityDTO
    )
    {
        _stateService.InsertCity(stateId,cityDTO);
        return Created("api/{stateId}/city", cityDTO);
    }


    /// <summary>
    /// Insere uma cidade ao estado
    /// </summary>
    /// <param name="stateId"> Id do estado à ser inserido o endereço</param>
    /// <param name="cityId"> Id da cidade à ser inserido o endereço</param>
    /// <param name="body"> Preencha o endereço à ser inserido</param>
    /// <response code="201">Registro criado.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Estado ou cidade não encontrados</response>
    [HttpPost("{stateId}/city/{cityId}/address")]
    public IActionResult PostAdress(
        [FromRoute] int stateId,
        [FromRoute] int cityId,
        [FromBody] AdressDTO body)
    {
        _stateService.InsertAdress(stateId, cityId, body);
        return Created($"api/state/{stateId}/city/{cityId}/", body);
    }

    /// <summary>
    /// Lista cidade cadastrada por seu id
    /// </summary>
    /// <param name="stateId">Id do estado à ser filtrado</param>
    /// <param name="cityId">Id da cidade à ser filtrada</param>
    /// <response code="200">Retorna cidade filtrada</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registro não encontrado</response>
    [HttpGet("{stateId}/city/{cityId}")]
    public IActionResult GetCityById(
        [FromRoute] int stateId,
        [FromRoute] int cityId
    )
    {
        return Ok(_stateService.GetCityById(stateId, cityId));
    }

    /// <summary>
    /// Lista estado cadastrada por seu id
    /// </summary>
    /// <param name="stateId">Id do estado à ser filtrado</param>
    /// <response code="200">Retorna estado filtrada</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registro não encontrado</response>
    [HttpGet("{stateId}")]
    public IActionResult GetStateById(
        [FromRoute] int stateId
    )
    {
        return Ok(_stateService.GetStateByID(stateId));
    }


    /// <summary>
    /// Lista os estados cadastrados
    /// </summary>
    /// <param name="name">Filtra pelo nome do estado</param>
    /// <response code="200">Retorna lista ou com filtros</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registros não encontrados</response>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] string name
    ) 
    {
        return Ok(_stateService.ListAll(name));
    }

    /// <summary>
    /// Lista as cidades cadastradas
    /// </summary>
    /// <param name="stateId">Id do estado à ser listado</param>
    /// <param name="name">Filtra pelo nome da cidade</param>
    /// <response code="200">Retorna lista ou com filtros</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registros não encontrados</response>
    [HttpGet("{stateId}/city")]
    public IActionResult GetCityByStateId(
        [FromRoute] int stateId,
        [FromQuery] string name
    )
    {
        return Ok(_stateService.GetCitiesByStateId(stateId, name));
    }

}

