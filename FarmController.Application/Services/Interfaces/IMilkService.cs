using FarmController.Application.InputObjects;

namespace FarmController.Application.Services.Interfaces
{
    public interface IMilkService
    {
        Task SetTemperatureSetPoint(SetMilkTemperatureInputObject inputObject);
    }
}
