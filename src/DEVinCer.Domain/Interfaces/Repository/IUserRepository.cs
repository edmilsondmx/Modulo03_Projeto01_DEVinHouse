using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IUserRepository : IBaseRepository<User, int>
{
    IList<Sale> GetBuyerByUserID(int id);
    IList<Sale> GetSalesByUserID(int id);
    void InsertSale(Sale sale);
    void InsertBuy(Sale buy);
}
