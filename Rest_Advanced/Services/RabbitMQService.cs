using MassTransit;

namespace Rest_Advanced.Services
{
    public class RabbitMQService
    {
        private readonly IBusControl _bus;

        public RabbitMQService(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task SendMessage<T>(T message) where T : class
        {
            await _bus.Publish(message);
        }
    }
}
