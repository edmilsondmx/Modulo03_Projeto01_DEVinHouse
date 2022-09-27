using DEVinCar.Domain.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IUserService
{
    IList<UserDTO> ListAll();
    UserDTO GetById(int id);
    IList<SaleCarDTO> GetBuyerByUserID(int id);
    IList<SaleCarDTO> GetSalesByUserID(int id);
    void Insert(UserDTO dto);
    void InsertSale(int userId, SaleDTO dto);
    void InsertBuy(int userId, BuyDTO dto);
    void DeleteUser(int id);
    
}
