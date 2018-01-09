using System;

// Chapter 4, Events, Standard Event Pattern

// Events can be virtual, overridden, abstract, or sealed. Events can also be static.
// .NET Framework: System.EventArgs, System.EventArgs<>
// Difference between delegates and events: events can only be triggered and null-assigned from the class that defines them. From the outside, they can only be called += and -=.
namespace csplay
{
    class PriceChangedEventArgs : System.EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    class Stock
    {
        string symbol;
        decimal price;

        public Stock(string symbol)
        {
            this.symbol = symbol;
        }

        // public event System.EventHandler PriceChanged;
        public event System.EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get { return price; }

            set
            {
                if (price == value)
                    return;

                decimal oldPrice = price;
                price = value;

                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price)); // or EventArgs.Empty
            }
        }
    }

    class TestEvents
    {
        public static void Start(string[] args)
        {
            Stock stock = new Stock("THPW");
            stock.Price = 27.10M;
            // Register with the PriceChanged event
            stock.PriceChanged += stock_PriceChanged;
            stock.Price = 31.59M;
        }

        static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                Console.WriteLine("Alert, 10% stock price increase!");
        }
    }
}

