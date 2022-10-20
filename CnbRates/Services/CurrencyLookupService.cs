using CnbRates.Model;

namespace CnbRates.Services
{
	public class CurrencyLookupService
	{
		private IDictionary<string, Currency> _currencies;

		public CurrencyLookupService()
		{
			_currencies = new Dictionary<string, Currency>();
		}

		public IEnumerable<Currency> GetCurrencies()
		{
			return _currencies.Values;
		}

		public Currency GetOrAdd(string currencyCode, string country, string name)
		{
			if (_currencies.TryGetValue(currencyCode, out Currency existingCurrency))
			{
				return existingCurrency;
			}

			var newCurrency = new Currency()
			{
				Code = currencyCode,
				Country = country,
				Name = name
			};

			_currencies.Add(currencyCode, newCurrency);
			return newCurrency;
		}
	}
}
