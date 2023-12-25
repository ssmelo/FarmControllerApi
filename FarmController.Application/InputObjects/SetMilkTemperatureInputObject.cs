namespace FarmController.Application.InputObjects
{
    public class SetMilkTemperatureInputObject : BaseMqttInputObject
    {
        public float Temperature { get; private set; }

        public SetMilkTemperatureInputObject(float temperature, string workArea) : base(workArea)
        {
            Temperature = temperature;
        }
    }
}
