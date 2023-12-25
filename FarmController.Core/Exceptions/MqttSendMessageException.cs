namespace FarmController.Core.Exceptions
{
    public class MqttSendMessageException : BaseException
    {
        public MqttSendMessageException(string? message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
