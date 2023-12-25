namespace FarmController.Application.Ports
{
    public interface IMqttCommunicator
    {
        Task SendMessage(object message, string topicName);
    }
}
