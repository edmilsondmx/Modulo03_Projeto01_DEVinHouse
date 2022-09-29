using DEVinCar.Domain.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IUserService
{
    IList<UserDTO> ListAll();
    IList<UserDTO> ListAll(string name, DateTime? birthDateMax, DateTime? birthDateMin);
    UserDTO GetById(int id);
    IList<SaleDTO> GetBuyerByUserID(int id);
    IList<SaleDTO> GetSalesByUserID(int id);
    void Insert(UserDTO dto);
    void InsertSale(int userId, SaleDTO dto);
    void InsertBuy(int userId, BuyDTO dto);
    void DeleteUser(int id);
    
}
