using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IUserRepository
{
    IList<User> ListAll();
    User GetById(int id);
    IList<Sale> GetBuyerByUserID(int id);
    IList<Sale> GetSalesByUserID(int id);
    void Insert(User user);
    void InsertSale(Sale sale);
    void InsertBuy(Sale buy);
    void Delete(User user);
}
