using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs;

public class SaleDTO
{
    public int Id { get; internal set; }
    [Required(ErrorMessage = "The BuyerId is required.")]
    public int BuyerId { get; set; }
    public DateTime SaleDate { get; set; }
    public int SellerId { get; set; }
}

