namespace HS.AppointmentBooking.Domain.Services;

public class NowService : INowService
{
    public DateTime Now => DateTime.Now;
}