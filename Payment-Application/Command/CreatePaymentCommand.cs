using AutoMapper;
using FluentValidation;
using MassTransit;
using MediatR;
using Payment_Core.Domain;
using Payment_Persistence;

namespace Payment_Application.Command;
public class CreatePaymentCommand : IRequest<Guid>
{
    public Guid OrderId { get; set; }
    public DateTime PaidAt { get; set; } = DateTime.UtcNow;
}
public class CreatePaymentCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IPublishEndpoint _publishEndpoint) : IRequestHandler<CreatePaymentCommand, Guid>
{
    public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = _mapper.Map<Payment>(request);
        payment.Id = Guid.NewGuid();
        await _unitOfWork.PaymentRepository.AddAsync(payment);
        await _unitOfWork.CommitAsync(cancellationToken);
        return payment.Id;
    }
}
public class CreatePaymentCommandValidation : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidation()
    {
        RuleFor(x => x.OrderId).NotEmpty();
    }
}
