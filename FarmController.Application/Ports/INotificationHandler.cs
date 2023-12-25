namespace FarmController.Application.Ports
{
    public interface INotificationHandler
    {
        Task SendMessage(object message);
    }
}
