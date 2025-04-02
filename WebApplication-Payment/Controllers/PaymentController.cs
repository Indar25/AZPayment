using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment_Application.Command;

namespace WebApplication_Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(ISender _mediatR) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentCommand request)
        {
            var result = await _mediatR.Send(request);
            return Ok(result);
        }
    }
}
