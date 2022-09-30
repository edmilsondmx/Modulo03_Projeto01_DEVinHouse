using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs;

public class AddressPatchDTO
{
    [Required(ErrorMessage = "The street name cannot be empty.")]
    [MaxLength(150,ErrorMessage="Street name must be a maximum of 100 characters")]
    public string Street { get; set; }
    [Required(ErrorMessage = "The cep cannot be empty.")]
    [MaxLength(8,ErrorMessage="The CEP must have a maximum of 8 characters")]
    public string Cep { get; set; }
    [Required(ErrorMessage ="The number is required.")]
    public int Number { get; set; }
    [MaxLength(255,ErrorMessage="The Complement must have a maximum of 255 characters")]
    public string Complement { get; set; }

}
