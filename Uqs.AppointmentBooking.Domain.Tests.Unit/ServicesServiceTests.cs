using System.Linq;
using System.Threading.Tasks;
using HS.AppointmentBooking.Domain.Repository;
using HS.AppointmentBooking.Domain.Services;
using NSubstitute;
using Xunit;
using HS.AppointmentBooking.Domain.DomainObjects;

namespace HS.AppointmentBooking.Domain.Tests.Unit;

public class ServicesServiceTests
{
    private readonly IServiceRepository _serviceRepository = Substitute.For<IServiceRepository>();
    private ServicesService? _sut;

    [Fact]
    public async Task GetActiveServices_NoServiceInTheSystem_NoServices()
    {
        // Arrange
        _sut = new ServicesService(_serviceRepository);

        // Act
        var actual = await _sut.GetActiveServices();

        // Assert
        Assert.True(!actual.Any());
    }

    [Fact]
    public async Task GetActiveServices_TwoActiveServices_TwoServices()
    {
        // Arrange
        _serviceRepository.GetActiveServices()
            .Returns(new Service[] {
                new Service{IsActive = true},
                new Service{IsActive = true},
            });
        _sut = new ServicesService(_serviceRepository);
        var expected = 2;

        // Act
        var actual = await _sut.GetActiveServices();

        // Assert
        Assert.Equal(expected, actual.Count());
    }
}