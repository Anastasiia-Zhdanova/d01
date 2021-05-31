namespace d01_ex00.Models
{
    public struct ExchangeSum
    {
        private double sum;
        private string currency;

        public ExchangeSum(double sum, string currency)
        {
            this.sum = sum;
            this.currency = currency;
        }

        public double Sum => sum;

        public string Currency => currency;
        
        public override string ToString()
        {
            return ($"Сумма в {currency}: {sum:F2} {currency}");
        }
    }
}