using System;
using System.Collections.Generic;
using System.Linq;

namespace Observer.Domain
{
    public interface IInvestor
    {
        void Update(Stock stock);
    }

    public abstract class Stock
    {
        private double price;
        private readonly IList<IInvestor> investors = new List<IInvestor>();

        protected Stock(string symbol, double price)
        {
            Symbol = symbol;
            this.price = price;
        }

        public void Attach(IInvestor investor) => investors.Add(investor);
        public void Detach(IInvestor investor) => investors.Remove(investor);

        public void Notify()
        {
            investors.ToList().ForEach(investor => investor.Update(this));
            Console.WriteLine("");
        }

        public double Price { get { return price; }
            set
            {
                if(price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }

        public string Symbol { get; private set; }
    }

    internal class IBM : Stock
    {
        public IBM(string symbol, double price) : base(symbol, price)
        {
        }
    }

    internal class Investor : IInvestor
    {
        private readonly string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine($"Notificando {name} que {stock.Symbol} teve preço alterado para {stock.Price:C}");
        }

        public Stock Stock { get; set; }
    }

    public class Observer
    {
        public static void Execucao()
        {
            var ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Raphael"));
            ibm.Attach(new Investor("Rodrigo"));

            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
        }
    }
}
