using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
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
            throw new Exception("Não existe registro!");
            //TODO: Criar exception para lista vazia!
        
        _userRepository.Delete(userDb);

    }

    public IList<SaleDTO> GetBuyerByUserID(int id)
    {
        var buyerByUserId = _userRepository.GetBuyerByUserID(id);
        if(!buyerByUserId.ToList().Any())
            throw new Exception("Não existe registro!");
            //TODO: Criar exception para lista vazia!
        
        return _mapper.Map<IList<SaleDTO>>(buyerByUserId);
    }

    public UserDTO GetById(int id)
    {
        var userDb = _userRepository.GetById(id);
        if(userDb == null)
            throw new Exception("Não existe registro!");
            //TODO: Criar exception para lista vazia!
        
        return _mapper.Map<UserDTO>(userDb);
    }

    public IList<SaleDTO> GetSalesByUserID(int id)
    {
        var salesByUserId = _userRepository.GetSalesByUserID(id);
        if(!salesByUserId.ToList().Any())
            throw new Exception("Não existe registro!");
            //TODO: Criar exception para lista vazia!
        
        return _mapper.Map<IList<SaleDTO>>(salesByUserId);
    }

    public void Insert(UserDTO dto)
    {
        if(IsExists(dto))
            throw new Exception("Usuario já cadastrado");
            //TODO: Criar exception usuario já cadastrado!
        
        _userRepository.Insert(_mapper.Map<User>(dto));
    }

    public void InsertBuy(int userId, BuyDTO dto)
    {
        var userDb = _userRepository.GetById(userId);
        var seller = _userRepository.GetById(dto.SellerId);

        if(!IsExists(_mapper.Map<UserDTO>(userDb)))
            throw new Exception("Usuario não encontrado!");
            //TODO: Criar exception usuario já cadastrado!

        if(!IsExists(_mapper.Map<UserDTO>(seller)))
            throw new Exception("Comprador não encontrado!");
            //TODO: Criar exception usuario já cadastrado!
        
        Sale buy = _mapper.Map<Sale>(dto);
        buy.BuyerId = userId;

        _userRepository.InsertSale(buy);
    }

    public void InsertSale(int userId, SaleDTO dto)
    {
        var userDb = _userRepository.GetById(userId);
        var buyer = _userRepository.GetById(dto.BuyerId);

        if(!IsExists(_mapper.Map<UserDTO>(userDb)))
            throw new Exception("Usuario não encontrado!");
            //TODO: Criar exception usuario já cadastrado!

        if(!IsExists(_mapper.Map<UserDTO>(buyer)))
            throw new Exception("Comprador não encontrado!");
            //TODO: Criar exception usuario já cadastrado!
        
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
            throw new Exception("Não existe registro!");
            //TODO: Criar exception para lista vazia!
        
        return _mapper.Map<IList<UserDTO>>(query).ToList();
    }

    public IList<UserDTO> ListAll()
    {
        throw new NotImplementedException();
    }

    private bool IsExists(UserDTO user)
    {
        return _userRepository.ListAll()
            .Any(u => u.Email == user.Email);
        
    }
}
