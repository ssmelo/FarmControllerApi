namespace FarmController.Application.InputObjects
{
    public abstract class BaseMqttInputObject
    {
        public string WorkArea { get; private set; }

        protected BaseMqttInputObject(string workArea)
        {
            WorkArea = workArea;
        }
    }
}
