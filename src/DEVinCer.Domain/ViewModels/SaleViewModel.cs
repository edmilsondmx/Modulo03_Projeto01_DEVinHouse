namespace DEVinCar.Domain.ViewModels;
public class SaleViewModel
{
    public string SellerName { get; set; }
    public string BuyerName { get; set; }
    public DateTime SaleDate { get; set; }
    public virtual List<CarViewModel> Itens { get; set; }
    public SaleViewModel()
    {
    }
}