using System;

namespace Facade.Domain
{
    internal class Bank
    {
        public bool HasSufficientSaving(Customer c, int amount)
        {
            Console.WriteLine($"Validar limite para {c.Name}");
            return true;
        }
    }

    internal class Credit
    {
        public bool HasGoodCredit(Customer c, int amount)
        {
            Console.WriteLine($"Validar credito para {c.Name}");
            return true;
        }
    }

    internal class Loan
    {
        public bool HasGoodCredit(Customer c, int amount)
        {
            Console.WriteLine($"Validar emprestimo para {c.Name}");
            return true;
        }
    }

    internal class Customer
    {
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }
    }

    internal class Mortgage
    {
        private readonly Bank bank = new Bank();
        private readonly Loan loan = new Loan();
        private readonly Credit credit = new Credit();

        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine($"{cust.Name} aprovado para emprestimo de {amount:C}");

            var eligible = true;
            if(!bank.HasSufficientSaving(cust, amount))
            {
                eligible = false;
            }
            else if (!loan.HasGoodCredit(cust, amount))
            {
                eligible = false;
            }
            else if(!credit.HasGoodCredit(cust, amount))
            {
                eligible = false;
            }

            return eligible;
        }
    }

    public class Facade
    {
        public static void Execucao()
        {
            var mortgage = new Mortgage();
            var customer = new Customer("Raphael");

            var eligible = mortgage.IsEligible(customer, 1000);

            Console.WriteLine($"Cliente {customer.Name} permitido emprestimo: {eligible}");
        }
    }
}
