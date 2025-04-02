using AutoMapper;
using Payment_Application.Command;
using Payment_Core.Domain;

namespace Payment_Application;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<CreatePaymentCommand, Payment>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}


