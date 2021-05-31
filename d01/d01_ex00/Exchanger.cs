using System.Collections.Generic;
using System.IO;
using d01_ex00.Models;

namespace d01_ex00
{
    public class Exchanger
    {
        private List<ExchangeRate> listExchangeRates;
            
        public Exchanger(List<ExchangeRate> listExchangeRates)
        {
            this.listExchangeRates = listExchangeRates;
        }

        public List<ExchangeSum> Exchange(string currency, double sum)
        {
            var list = new List<ExchangeSum>();
            foreach (var exchangeRate in listExchangeRates)
            {
                if (exchangeRate.FromCurrency.Equals(currency))
                {
                    list.Add(new ExchangeSum(sum * exchangeRate.Rate, exchangeRate.ToCurrency));
                }
            }
            return list;
        }
    }
}