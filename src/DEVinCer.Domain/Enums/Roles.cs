using System.ComponentModel.DataAnnotations;

namespace DEVinCer.Domain.Enums;

public enum Roles
{
    [Display(Name = "Manager")]
    Manager = 1,
    [Display(Name = "Seller")]
    Seller,
    [Display(Name = "Buyer")]
    Buyer
}
