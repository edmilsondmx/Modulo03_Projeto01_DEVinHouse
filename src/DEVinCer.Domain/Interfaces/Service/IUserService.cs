using DEVinCer.Domain.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IUserService
{
    UserDTO GetByUser(LoginDTO login);
    IList<UserDTO> ListAll(string name, DateTime? birthDateMax, DateTime? birthDateMin);
    UserDTO GetById(int id);
    IList<SaleDTO> GetBuyerByUserID(int id);
    IList<SaleDTO> GetSalesByUserID(int id);
    void Insert(UserDTO dto);
    void InsertSale(int userId, SaleDTO dto);
    void InsertBuy(int userId, BuyDTO dto);
    void DeleteUser(int id);
    void Update(int id, UserDTO user);
}
