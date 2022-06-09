namespace AuthService.EventManager
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}