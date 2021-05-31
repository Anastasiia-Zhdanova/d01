namespace d01_ex00.Models
{
    public struct ExchangeRate
    {
        private string fromCurrency;
        private string toCurrency;
        private double rate;

        public ExchangeRate(string fromCurrency, string toCurrency, double rate)
        {
            this.fromCurrency = fromCurrency;
            this.toCurrency = toCurrency;
            this.rate = rate;
        }
        
        public string FromCurrency
        {
            get => fromCurrency;
        }

        public string ToCurrency
        {
            get => toCurrency;
        }

        public double Rate
        {
            get => rate;
        }
    }
}