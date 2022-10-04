using DEVinCar.Domain.DTOs;
using DEVinCer.Domain.Enums;
using DEVinCer.Domain.ViewModels;

namespace DEVinCer.Domain.Services;

public static class ConverterUser
{
    public static UserViewModel ToDto(UserDTO dto)
    {
        return new UserViewModel{
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            BirthDate = dto.BirthDate,
            Role = dto.Role.GetName(),
        };
    }
    public static IList<UserViewModel> ToDto(IList<UserDTO> listDto)
    {
        return listDto.Select(f => ToDto(f)).ToList();
    }
}
