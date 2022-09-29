using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs;

public class SaleDTO
{
    public int Id { get; internal set; }
    [Required(ErrorMessage = "The BuyerId is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "BuyerId Invalid.")]
    public int BuyerId { get; set; }
    [Required(ErrorMessage = "The SaleDate is required.")]
    public DateTime SaleDate { get; set; }
    public int SellerId { get; set; }

    public SaleDTO()
    {
    }
}

