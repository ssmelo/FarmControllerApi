using FarmController.Application.Ports;

namespace FarmController.Application.Factories
{
    public interface INotificationFactory
    {
        INotificationHandler GetMqttNotificationHandler(string name);
    }
}
