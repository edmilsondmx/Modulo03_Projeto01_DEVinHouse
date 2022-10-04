using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using DEVinCar.Api.Config;
using DEVinCer.Domain.Services;

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

    [HttpGet("{carId}")]
    public IActionResult GetById(
        [FromRoute] int carId
    )
    {
        CarDTO carDb;

        if(!_carCache.TryGetValue($"{carId}", out carDb))
        {
            carDb = _carService.GetById(carId);
            _carCache.Set($"{carId}", carDb);
        }

        return Ok(carDb);
    }

    [HttpGet]
    public IActionResult Get(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax
    )
    {
        return Ok(_carService.ListAll(name, priceMin, priceMax));
    }

    [HttpPost]
    public IActionResult Post(
        [FromBody] CarDTO carDto
    )
    {
        _carService.Insert(carDto);
        return Created("api/car", carDto);
    }

    [HttpDelete("{carId}")]
    public IActionResult Delete(
        [FromRoute] int carId
    )
    {
        _carService.Delete(carId);
        _carCache.Remove($"{carId}");

        return NoContent();
    }

    [HttpPut("{carId}")]
    public ActionResult<Car> Put(
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
}
