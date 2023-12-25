using FarmController.Api.Options;
using FarmController.Application.Ports;
using FarmController.Core.Exceptions;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using System.Text.Json;


namespace FarmController.Infrastructure.Mqtt
{
    public class MqttCommunicator : IMqttCommunicator
    {
        private readonly Lazy<Task<IMqttClient>> _mqttClient;
        private readonly MqttOptions _mqttOptions;

        public MqttCommunicator(IOptions<MqttOptions> options)
        {
            _mqttOptions = options.Value;

            _mqttClient = new Lazy<Task<IMqttClient>>(async () =>
            {
                var mqttClient = new MqttFactory().CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer(_mqttOptions.BrokerHost).Build();
                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
                return mqttClient;
            });
        }

        public async Task SendMessage(object message, string topicName)
        {
            byte[] payload = JsonSerializer.SerializeToUtf8Bytes(message);

            var applicationMessage = new MqttApplicationMessageBuilder()
              .WithTopic(topicName)
              .WithPayload(payload)
              .Build();

            var client = await _mqttClient.Value;
            var response = await client.PublishAsync(applicationMessage);

            if (!response.IsSuccess)
                throw new MqttSendMessageException(response.ReasonString, 500);
        }
    }
}
