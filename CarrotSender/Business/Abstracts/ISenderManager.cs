namespace CarrotSender.Business.Abstracts
{
    public interface ISenderManager
    {
        bool IsBusReady { get; }
        void SendMessageToExchange(string exchange, string message);
        void SendMessageToQueue(string queue, string message);
    }
}