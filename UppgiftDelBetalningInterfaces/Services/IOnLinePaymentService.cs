

namespace UppgiftDelBetalningInterfaces.Services
{
    interface IOnLinePaymentService
    {
        double PaymentFee (double amount);
        double Interest (double amount, int months);
    }
}
