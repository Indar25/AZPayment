using MassTransit;
using MediatR;
using Payment_Application.Command;
using Shared.Contracts.Event;

namespace WebApplication_Payment.Messaging.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly ISender _sender;
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderCreatedConsumer(ISender sender, IPublishEndpoint publishEndpoint)
    {
        _sender = sender;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        try
        {
            await _sender.Send(new CreatePaymentCommand() { OrderId = context.Message.OrderId });
            await _publishEndpoint.Publish(new PaymentSucceededEvent(context.Message.OrderId));
        }
        catch (Exception ex)
        {
            await _publishEndpoint.Publish(new PaymentFailedEvent(context.Message.OrderId, ex.Message));
        }
    }
}
