using System.Globalization;
using UppgiftDelBetalningInterfaces.Entities;
using UppgiftDelBetalningInterfaces.Services;

Console.WriteLine("Enter contract data");

Console.Write("Number: ");
int number = int.Parse(Console.ReadLine());

Console.Write("Date (dd/MM/yyyy): ");
DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

Console.Write("Contract value: ");
double value = double.Parse(Console.ReadLine());

Console.Write("Enter number of installments: ");
int numberInstallment = int.Parse(Console.ReadLine());

Contract contract = new Contract(number, date, value);

ContractService contractService = new ContractService(new PaypalService());
contractService.ProcessContract(contract, numberInstallment);

Console.WriteLine("Installment:");
foreach (Installment installment in contract.Installments)
{
    Console.WriteLine(installment);
}