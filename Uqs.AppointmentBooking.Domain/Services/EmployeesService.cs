using Microsoft.Azure.Cosmos;
using HS.AppointmentBooking.Domain.DomainObjects;
using HS.AppointmentBooking.Domain.Repository;

namespace HS.AppointmentBooking.Domain.Services;

public interface IEmployeesService
{
    Task<IEnumerable<Employee>> GetEmployees();
}

public class EmployeesService : IEmployeesService
{
    private readonly IEmployeeRepository employeesRepository;

    public EmployeesService(IEmployeeRepository employeesRepository)
    {
        this.employeesRepository = employeesRepository;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
        => await employeesRepository.GetAllAsync();
}