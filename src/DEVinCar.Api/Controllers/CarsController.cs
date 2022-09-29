using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Infra.Data;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.Interfaces.Service;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("{carId}")]
    public IActionResult GetById(
        [FromRoute] int carId
    )
    {
        return Ok(_carService.GetById(carId));
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
        [FromBody] CarDTO body
    )
    {
        _carService.Insert(body);
        return Created("api/car", body);
    }

    [HttpDelete("{carId}")]
    public IActionResult Delete(
        [FromRoute] int carId
    )
    {
        _carService.Delete(carId);
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
        return NoContent();
    }
}
