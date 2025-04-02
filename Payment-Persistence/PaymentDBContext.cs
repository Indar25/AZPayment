using Microsoft.EntityFrameworkCore;
using Payment_Core.Domain;

namespace Payment_Persistence;

public class PaymentDBContext :DbContext
{
    public PaymentDBContext(DbContextOptions opt) :base(opt)
    {
        
    }
    public DbSet<Payment> Payment { get; set; }
}

