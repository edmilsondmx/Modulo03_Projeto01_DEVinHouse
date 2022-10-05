using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace DEVinCer.Domain.Enums;

public enum Roles
{
    [XmlEnumAttribute("A")]
    [Display(Name = "Admin")]
    Admin,

    [XmlEnumAttribute("M")]
    [Display(Name = "Manager")]
    Manager,
    
    [XmlEnumAttribute("S")]
    [Display(Name = "Seller")]
    Seller,

    [XmlEnumAttribute("B")]
    [Display(Name = "Buyer")]
    Buyer
}
