using HS.AppointmentBooking.Domain.DomainObjects;
using HS.AppointmentBooking.Domain.Repository;

namespace HS.AppointmentBooking.Domain.Services;

public interface IServicesService
{
    Task<Service?> GetService(string id);

    Task<IEnumerable<Service>> GetActiveServices();
}

public class ServicesService : IServicesService
{
    private readonly IServiceRepository _serviceRepository;

    public ServicesService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<IEnumerable<Service>> GetActiveServices()
        => await _serviceRepository.GetActiveServices();

    public async Task<Service?> GetService(string id)
        => await _serviceRepository.GetActiveService(id);


    //public Task<IEnumerable<Service>> GetActiveServices()
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<Service?> GetService(string id)
    //{
    //    throw new NotImplementedException();
    //}
}