using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IUserRepository
{
    IList<User> ListAll();
    User GetById(int id);
    IList<SaleCar> GetBuyerByUserID(int id);
    IList<SaleCar> GetSalesByUserID(int id);
    void Insert(User user);
    void InsertSale(Sale sale);
    void InsertBuy(Sale buy);
    void Delete(User user);
}
