using Amazon.SQS;
using Amazon.SQS.Model;
using FarmController.Application.Ports;
using System.Text.Json;

namespace FarmController.Infrastructure.CloudServices.sqs
{
    public class SqsNotificationHandler : INotificationHandler
    {
        private readonly string _queueUrl;
        private readonly IAmazonSQS _sqsClient;

        public SqsNotificationHandler(string queueUrl, IAmazonSQS sqsClient)
        {
            _queueUrl = queueUrl;
            this._sqsClient = sqsClient;
        }

        public async Task SendMessage(object message)
        {
            SendMessageRequest request = new SendMessageRequest
            {
                QueueUrl = _queueUrl,
                MessageBody = JsonSerializer.Serialize(message)
            };

            await _sqsClient.SendMessageAsync(request);
        }
    }
}
