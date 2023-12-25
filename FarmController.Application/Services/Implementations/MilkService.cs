using FarmController.Api.Options;
using FarmController.Application.Factories;
using FarmController.Application.Factories.Constants;
using FarmController.Application.InputObjects;
using FarmController.Application.Ports;
using FarmController.Application.Services.Interfaces;
using FarmController.Core.Models;
using Microsoft.Extensions.Options;

namespace FarmController.Application.Services.Implementations
{
    public class MilkService : IMilkService
    {

        private readonly string TEMPERATURE_TOPIC_NAME = "{0}/{1}";

        private readonly IMqttCommunicator _mqttCommunicator;

        private readonly INotificationHandler _notificationHandler;
        private readonly MqttOptions _mqttOptions;

        public MilkService(IMqttCommunicator mqttCommunicator, INotificationFactory notificationFactory, IOptions<MqttOptions> options)
        {
            _mqttCommunicator = mqttCommunicator;
            _notificationHandler = notificationFactory.GetMqttNotificationHandler(NotificationConstants.SQS_NOTIFICATION_INSTANCE);
            _mqttOptions = options.Value;
        }

        public async Task SetTemperatureSetPoint(SetMilkTemperatureInputObject inputObject)
        {
            var payloadMessage = new MilkTemperatureModel(inputObject.Temperature);

            await _mqttCommunicator.SendMessage(payloadMessage, string.Format(TEMPERATURE_TOPIC_NAME, inputObject.WorkArea, _mqttOptions.TopicName));

            await _notificationHandler.SendMessage(payloadMessage);
        }
    }
}
