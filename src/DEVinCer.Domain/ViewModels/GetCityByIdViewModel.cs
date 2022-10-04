using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.ViewModels;

public class GetCityByIdViewModel
{
    public int cityId { get; set; }
    public string cityName { get; set; }
    public int stateId { get; set; }
    public string stateName { get; set; }
    public string stateInitials { get; set; }

    public GetCityByIdViewModel(State state, City city)
    {
        cityId = city.Id;
        cityName = city.Name;
        stateId = state.Id;
        stateName = state.Name;
        stateInitials = state.Initials;
    }
}