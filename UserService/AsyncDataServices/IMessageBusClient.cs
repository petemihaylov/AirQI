using UserService.DataTransfer;

namespace UserService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewUser(UserPublishDto userPublishDto);
    }
}