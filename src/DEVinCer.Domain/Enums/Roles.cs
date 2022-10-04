using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace DEVinCer.Domain.Enums;

public enum Roles
{
    [XmlEnumAttribute("M")]
    [Display(Name = "Manager")]
    Manager = 1,
    
    [XmlEnumAttribute("S")]
    [Display(Name = "Seller")]
    Seller,

    [XmlEnumAttribute("B")]
    [Display(Name = "Buyer")]
    Buyer
}
