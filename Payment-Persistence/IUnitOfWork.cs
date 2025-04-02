using Payment_Core.Domain;

namespace Payment_Persistence;
public interface IUnitOfWork
{
    IRepository<Payment> PaymentRepository { get; }
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}

public class UnitOfWork(PaymentDBContext context) : IUnitOfWork
{
    private IRepository<Payment> _paymentRepository;
    public IRepository<Payment> PaymentRepository => _paymentRepository ?? (_paymentRepository = new GeneralRepository<Payment>(context));

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default) => await context.SaveChangesAsync(cancellationToken);


}
