using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCer.Domain.Interfaces.Repository;
using DEVinCer.Domain.Interfaces.Service;

namespace DEVinCer.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper  _mapper;

    public UserService(IUserRepository userRepository, IMapper  mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

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

    public IList<UserDTO> ListAll(string name, DateTime? birthDateMax, DateTime? birthDateMin)
    {
        var query =  _userRepository.ListAll().AsQueryable();
        
        if(!String.IsNullOrEmpty(name))
            query = query.Where(u => u.Name.Contains(name));

        if (birthDateMin.HasValue)
            query = query.Where(c => c.BirthDate >= birthDateMin.Value);
        
        if (birthDateMax.HasValue)
            query = query.Where(c => c.BirthDate <= birthDateMax.Value);

        if (!query.ToList().Any())
            throw new Exception("Não existe registro!");
            //TODO: Criar exception para lista vazia!
        
        return _mapper.Map<IList<UserDTO>>(query).ToList();
    }

    public IList<UserDTO> ListAll()
    {
        throw new NotImplementedException();
    }
}
