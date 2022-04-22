using ExceptionLession.Entities;
using ExceptionLession.Entities.Exceptions;
using System.Globalization;

try
{
    Console.WriteLine("Enter account data");
    Console.Write("Number: ");
    int number = int.Parse(Console.ReadLine());
    Console.Write("Holder: ");
    string holder = Console.ReadLine();
    Console.Write("Initial balance: ");
    double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    Console.Write("Withdraw limit: ");
    double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Account account = new Account(number, holder, withdrawLimit);
    account.Deposit(initialBalance);

    Console.WriteLine();
    Console.Write("Enter amount for withdraw: ");
    double withdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    account.Withdraw(withdraw);

    Console.WriteLine(account);

} catch (DomainException e)
{
    Console.WriteLine(e.Message);
} catch (Exception e)
{
    Console.WriteLine($"Application Error: {e.Message}");
}
