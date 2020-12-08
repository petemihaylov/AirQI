namespace AirQi.Settings
{
    public interface IWorkerSettings
    {
        string OcpApimSubscriptionKey { get; set; }

        string AqicnSubscriptionKey { get; set; }
    }
}