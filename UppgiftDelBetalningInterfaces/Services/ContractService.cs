using UppgiftDelBetalningInterfaces.Entities;

namespace UppgiftDelBetalningInterfaces.Services
{
    class ContractService
    {
        private IOnLinePaymentService _onLinePaymentService;

        public ContractService(IOnLinePaymentService onLinePaymentService)
        {
            _onLinePaymentService = onLinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double startPayment = contract.TotalValue / months;

            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = startPayment + _onLinePaymentService.Interest(startPayment, i);
                double fullquota = updatedQuota + _onLinePaymentService.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullquota));
            }
        }
    }
}
