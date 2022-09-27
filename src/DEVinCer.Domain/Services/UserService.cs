using DEVinCar.Domain.DTOs;
using DEVinCer.Domain.Interfaces.Service;

namespace DEVinCer.Domain.Services;

public class UserService : IUserService
{
    public void DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public IList<SaleCarDTO> GetBuyerByUserID(int id)
    {
        throw new NotImplementedException();
    }

    public UserDTO GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IList<SaleCarDTO> GetSalesByUserID(int id)
    {
        throw new NotImplementedException();
    }

    public void Insert(UserDTO dto)
    {
        throw new NotImplementedException();
    }

    public void InsertBuy(int userId, BuyDTO dto)
    {
        throw new NotImplementedException();
    }

    public void InsertSale(int userId, SaleDTO dto)
    {
        throw new NotImplementedException();
    }

    public IList<UserDTO> ListAll()
    {
        throw new NotImplementedException();
    }
}
