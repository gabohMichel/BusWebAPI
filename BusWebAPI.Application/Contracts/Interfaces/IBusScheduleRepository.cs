using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;

namespace BusWebAPI.Application.Contracts.Interfaces
{
    public interface IBusScheduleRepository
    {
        Task<BusSchedule> Get(int id);
        Task<List<BusSchedule>> GetList(
            DateTime? departureTime = null, 
            DateTime? arrivingTime = null,
            bool? castDateTimeToDate = null,
            string? departurePoint = null, 
            string? arrivingPoint = null,
            int? idBus = null,
            string? plates = null,
            int? idRoute = null,
            bool? isAvailable = null,
            int[] notContainsId = null);
        Task<BusSchedule> Create(TabBusSchedule busSchedule);
        Task<bool> Update(TabBusSchedule busSchedule);
        Task<bool> Delete(int id);
    }
}
