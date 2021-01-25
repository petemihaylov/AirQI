namespace AirQi.Settings
{
    public class WorkerSettings : IWorkerSettings
    {
        public string OcpApimSubscriptionKey { get; set; }

        public string AqicnSubscriptionKey { get; set; }
    }
}