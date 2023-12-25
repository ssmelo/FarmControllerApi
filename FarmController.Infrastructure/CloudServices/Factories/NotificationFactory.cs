using Amazon.SQS;
using FarmController.Application.Factories.Constants;
using FarmController.Application.Options;
using FarmController.Application.Ports;
using FarmController.Infrastructure.CloudServices.sqs;
using Microsoft.Extensions.Options;

namespace FarmController.Application.Factories.Implementations
{
    public class NotificationFactory : INotificationFactory
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly SqsOptions _config;

        public NotificationFactory(IAmazonSQS sqsClient, IOptions<SqsOptions> options)
        {
            _sqsClient = sqsClient;
            _config = options.Value;
        }

        public INotificationHandler GetMqttNotificationHandler(string name)
        {
            return name switch
            {
                NotificationConstants.SQS_NOTIFICATION_INSTANCE => new SqsNotificationHandler(_config.Url, _sqsClient),
                _ => new SqsNotificationHandler(_config.Url, _sqsClient)
            };
        }
    }
}
