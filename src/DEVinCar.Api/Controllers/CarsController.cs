using Microsoft.AspNetCore.Mvc;
using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Models;
using DEVinCer.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using DEVinCar.Api.Config;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Manager")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IMemoryCache _cache;
    private readonly CacheService<CarDTO> _carCache;
    public CarController(ICarService carService, IMemoryCache cache, CacheService<CarDTO> carCache)
    {
        _carService = carService;
        _cache = cache;
        _carCache = carCache;
        carCache.Config("car", new TimeSpan(0,5,0));
    }


    /// <summary>
    /// Lista o veiculo cadastrado por seu id
    /// </summary>
    /// <param name="carId">Id do veículo à ser filtrado</param>
    /// <response code="200">Retorna veiculo filtrado</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="403">Não autorizado</response>
    /// <response code="404">Registro não encontrado</response>
    [HttpGet("{carId}")]
    public IActionResult GetById(
        [FromRoute] int carId
    )
    {
        var uri = $"{Request.Scheme}://{Request.Host}";
        CarDTO carDb;

        if(!_carCache.TryGetValue($"{carId}", out carDb))
        {
            carDb = _carService.GetById(carId);
            _carCache.Set($"{carId}", carDb);
            carDb.Links = GetHateoas(carDb, uri);
        }

        return Ok(carDb);
    }


    /// <summary>
    /// Lista os veiculos cadastrados
    /// </summary>
    /// <param name="name">Filtra pelo nome do carro</param>
    /// <param name="priceMin">Filtra pelo valor mínimo</param>
    /// <param name="priceMax">Filtra pelo valor máximo</param>
    /// <param name="skip">Pula quantos registros</param>
    /// <param name="take">Mostra quantos registros</param>
    /// <response code="200">Retorna lista ou com filtros</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="403">Não autorizado</response>
    /// <response code="404">Registros não encontrados</response>
    [HttpGet]
    public IActionResult Get(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax,
        int skip = 0,
        int take = 10
    )
    {
        var uri = $"{Request.Scheme}://{Request.Host}";
        var pagination = new Pagination(take, skip);
        var totalRegisters = _carService.GetTotal();

        Response.Headers.Add("x-Pagination-TotalRegisters", totalRegisters.ToString());

        var cars = new BaseDTO<IList<CarDTO>>(){
            Data = _carService.ListAll(name, priceMin, priceMax, pagination).ToList(),
            Links = GetHateoasForAll(uri, take, skip, totalRegisters)
        };

        foreach (var car in cars.Data)
        {
            car.Links = GetHateoas(car, uri);
        }

        return Ok(cars);
    }

    /// <summary>
    ///Insere um veiculo no bando de dados 
    /// </summary>
    /// <param name="carDto"> Preencha os dados a serem inseridos</param>
    /// <response code="201">Registro criado.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="403">Não autorizado</response>
    [HttpPost]
    public IActionResult Post(
        [FromBody] CarDTO carDto
    )
    {
        _carService.Insert(carDto);
        return Created("api/car", carDto);
    }

    /// <summary>
    /// Deleta um veiculo conforme o Id Informado
    /// </summary>
    /// <param name="carId">O Id do veiculo à ser deletado.</param>
    /// <response code="204">Veículo Deletado</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="403">Não autorizado</response>
    /// <response code="404">Veículo não encontrado</response>
    [HttpDelete("{carId}")]
    public IActionResult Delete(
        [FromRoute] int carId
    )
    {
        _carService.Delete(carId);
        _carCache.Remove($"{carId}");

        return NoContent();
    }

    /// <summary>
    ///Atualiza dados de um veículo
    /// </summary>
    /// <param name="carDto"></param>
    /// <param name="carId">Id do veículo à ser alterado</param>
    /// <response code="204">Veículo alterado com sucesso</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="403">Não autorizado</response>
    /// <response code="404">Veículo não encontrado</response>
    [HttpPut("{carId}")]
    public IActionResult Put(
        [FromRoute] int carId,
        [FromBody] CarDTO carDto
    )
    {
        carDto.Id = carId;
        _carService.Update(carDto);
        _carCache.Remove($"{carId}");
        _carCache.Set($"{carId}", carDto);

        return NoContent();
    }

    private List<HateoasDTO> GetHateoas(CarDTO car, string baseUri)
    {
        var hateoas =  new List<HateoasDTO>(){
            new HateoasDTO(){
                Rel = "self",
                Type = "Get",
                URI = $"{baseUri}/api/car/{car.Id}"
            },
            new HateoasDTO(){
                Rel = "car",
                Type = "Put",
                URI = $"{baseUri}/api/car/{car.Id}"
            },
            new HateoasDTO(){
                Rel = "car",
                Type = "Delete",
                URI = $"{baseUri}/api/car/{car.Id}"
            }
        };
        return hateoas;
    }

    private List<HateoasDTO> GetHateoasForAll( string baseUri, int take, int skip, int ultimo)
    {
        var hateoas =   new List<HateoasDTO>(){
            new HateoasDTO(){
                Rel = "self",
                Type = "Get",
                URI = $"{baseUri}/api/car?skip={skip}&take={take}"
            },
            new HateoasDTO(){
                Rel = "car",
                Type = "Post",
                URI = $"{baseUri}/api/car/"
            }
        };
        var razao = take - skip;
        if(skip != 0)
        {
            var newSkip = skip - razao;
            if(newSkip < 0)
            {
                newSkip = 0;
            }
            hateoas.Add(new HateoasDTO()
                {
                    Rel = "prev",
                    Type = "Get",
                    URI = $"{baseUri}/api/car?skip={newSkip}&take={take - razao}"
                }
            );
        }

        if(take < ultimo)
        {
            hateoas.Add(new HateoasDTO()
                {
                    Rel = "next",
                    Type = "Get",
                    URI = $"{baseUri}/api/car?skip={skip + razao}&take={take + razao}"
                }
            );
        }

        return hateoas;
    }
}
