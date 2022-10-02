using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.Exceptions;
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
        var userDb = _userRepository.GetById(id);
        if(userDb == null)
            throw new IsExistsException("User not found!");
        
        _userRepository.Delete(userDb);
    }

    public IList<SaleDTO> GetBuyerByUserID(int id)
    {
        var buyerByUserId = _userRepository.GetBuyerByUserID(id);
        if(!buyerByUserId.ToList().Any())
            throw new IsExistsException("Registers not found!");
        
        return _mapper.Map<IList<SaleDTO>>(buyerByUserId);
    }

    public UserDTO GetById(int id)
    {
        var userDb = _userRepository.GetById(id);
        if(userDb == null)
            throw new IsExistsException("User not found!");
        
        return _mapper.Map<UserDTO>(userDb);
    }

    public IList<SaleDTO> GetSalesByUserID(int id)
    {
        var salesByUserId = _userRepository.GetSalesByUserID(id);
        if(!salesByUserId.ToList().Any())
            throw new IsExistsException("Registers not found!");
        
        return _mapper.Map<IList<SaleDTO>>(salesByUserId);
    }

    public void Insert(UserDTO dto)
    {
        if(IsExists(dto))
            throw new NotAcceptableException("User already registered!");
        
        _userRepository.Insert(_mapper.Map<User>(dto));
    }

    public void InsertBuy(int userId, BuyDTO dto)
    {
        var userDb = _userRepository.GetById(userId);
        var seller = _userRepository.GetById(dto.SellerId);

        if(!IsExists(_mapper.Map<UserDTO>(userDb)))
            throw new IsExistsException("User not found!");

        if(!IsExists(_mapper.Map<UserDTO>(seller)))
            throw new IsExistsException("Seller not found!");
        
        Sale buy = _mapper.Map<Sale>(dto);
        buy.BuyerId = userId;

        _userRepository.InsertBuy(buy);
    }

    public void InsertSale(int userId, SaleDTO dto)
    {
        var userDb = _userRepository.GetById(userId);
        var buyer = _userRepository.GetById(dto.BuyerId);

        if(!IsExists(_mapper.Map<UserDTO>(userDb)))
            throw new IsExistsException("User not found!");

        if(!IsExists(_mapper.Map<UserDTO>(buyer)))
            throw new IsExistsException("Buyer not found!");
        
        dto.SellerId = userId;
        _userRepository.InsertSale(_mapper.Map<Sale>(dto));
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
            throw new IsExistsException("Registers not found!");
            //TODO: Criar exception para lista vazia!
        
        return _mapper.Map<IList<UserDTO>>(query).ToList();
    }

    private bool IsExists(UserDTO user)
    {
        return _userRepository.ListAll()
            .Any(u => u.Email == user.Email);
        
    }
}
