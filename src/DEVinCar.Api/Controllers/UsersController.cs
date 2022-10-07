using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using DEVinCer.Domain.Services;
using DEVinCer.Domain.Enums;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Lista os usuários cadastrados
    /// </summary>
    /// <param name="name">Filtra pelo nome do usuario</param>
    /// <param name="birthDateMax">Filtra pela data de nascimanto mínima</param>
    /// <param name="birthDateMin">a data de nascimanto máxima</param>
    /// <response code="200">Retorna lista ou com filtros</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registros não encontrados</response>
    [HttpGet]
    public IActionResult Get(
       [FromQuery] string name,
       [FromQuery] DateTime? birthDateMax,
       [FromQuery] DateTime? birthDateMin
    )
    {
        if(!User.IsInRole(Roles.Admin.GetName()))
            return Ok(ConverterUser.ToDto(_userService.ListAll(name, birthDateMax, birthDateMin)));
        
        return Ok(_userService.ListAll(name, birthDateMax, birthDateMin));
    }

    /// <summary>
    /// Lista o usuário cadastrado por seu id
    /// </summary>
    /// <param name="id">Id do usuário à ser filtrado</param>
    /// <response code="200">Retorna usuário filtrado</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registro não encontrado</response>
    [HttpGet("{id}")]
    public IActionResult GetById(
        [FromRoute] int id
    )
    {
        if(!User.IsInRole(Roles.Admin.GetName()))
            return Ok(ConverterUser.ToDto(_userService.GetById(id)));

        return Ok(_userService.GetById(id));
    }

    /// <summary>
    /// Lista as compras por usuário
    /// </summary>
    /// <param name="userId">Id do usuário à ser listado</param>
    /// <response code="200">Retorna lista ou com filtro</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registros não encontrados</response>
    [HttpGet("{userId}/buy")]
    public IActionResult GetByIdbuy(
       [FromRoute] int userId
    )
    {
        return Ok(_userService.GetBuyerByUserID(userId));
    }

    /// <summary>
    /// Lista as vendas por usuário
    /// </summary>
    /// <param name="userId">Id do usuário à ser listado</param>
    /// <response code="200">Retorna lista ou com filtro</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Registros não encontrados</response>
    [HttpGet("{userId}/sales")]
    public IActionResult GetSalesBySellerId(
       [FromRoute] int userId
    )
    {
        return Ok(_userService.GetSalesByUserID(userId));
    }

    /// <summary>
    ///Insere um usuário no bando de dados 
    /// </summary>
    /// <param name="userDto"> Preencha os dados a serem inseridos</param>
    /// <response code="201">Registro criado.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    [HttpPost]
    public IActionResult Post(
        [FromBody] UserDTO userDto
    )
    {
        _userService.Insert(userDto);
        return Created("api/users", userDto);
    }

    /// <summary>
    /// Insere uma venda ao usuário
    /// </summary>
    /// <param name="userId"> Id do usuario à ser inserida a venda</param>
    /// <param name="body"> Preencha os dados da venda à ser inserida</param>
    /// <response code="201">Registro criado.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Usuário não encontrado</response>
    [HttpPost("{userId}/sales")]
    public IActionResult PostSaleUserId(
        [FromRoute] int userId,
        [FromBody] SaleDTO body
    )
    {
        _userService.InsertSale(userId, body);
        return Created("api/sale", body);
    }

    /// <summary>
    /// Insere uma compra ao usuário
    /// </summary>
    /// <param name="userId"> Id do usuario à ser inserida a compra</param>
    /// <param name="body"> Preencha os dados da compra à ser inserida</param>
    /// <response code="201">Registro criado.</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Usuário não encontrado</response>
    [HttpPost("{userId}/buy")]
    public IActionResult PostBuyUserId(
        [FromRoute] int userId,
        [FromBody] BuyDTO body
    )
    {
        _userService.InsertBuy(userId, body);
        return Created("api/user/{userId}/buy", body);
    }
      
    /// <summary>
    /// Deleta um usuário conforme o Id Informado
    /// </summary>
    /// <param name="userId">O Id do usuário à ser deletado.</param>
    /// <response code="204">Usuário Deletado</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Usuário não encontrado</response>
    [HttpDelete("{userId}")]
    public IActionResult Delete(
       [FromRoute] int userId
    )
    {
        _userService.DeleteUser(userId);
        return NoContent();
    }

    /// <summary>
    ///Atualiza dados de um usuário
    /// </summary>
    /// <param name="dto">Preencha os dados à ser alterado</param>
    /// <param name="userId">Id do usuário à ser alterado</param>
    /// <response code="204">Usuário alterado com sucesso</response>
    /// <response code="400">Erro ao fazer a Request</response>
    /// <response code="401">Não autenticado</response>
    /// <response code="404">Usuário não encontrado</response>
    [HttpPut("{userId}")]
    public IActionResult Put(
        [FromRoute] int userId,
        [FromBody] UserDTO dto
    )
    {
        _userService.Update(userId, dto);
        return NoContent();
    }
}





