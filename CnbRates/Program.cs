using System.Diagnostics;
using CnbRates.Model;
using CnbRates.Services;

var currenciesLookupService = new CurrencyLookupService();
var downloader = new ExchnageRateDownloader(currenciesLookupService);
var data = new List<ExchangeRate>();

const int Year = 2022;
DateTime day = new DateTime(Year, 1, 1);

while (day.Month == 1)
{
	if ((day.DayOfWeek != DayOfWeek.Saturday)
		&& (day.DayOfWeek != DayOfWeek.Sunday)
		&& (day <= DateTime.Today))
	{
		Console.WriteLine(day.ToString());
		var result = await downloader.DownloadDayAsync(day);
		data.AddRange(result);
	}
	day = day.AddDays(1);
}


// zápis do DB
var persister = new DbPersister();
await persister.SaveCurrenciesAsync(currenciesLookupService.GetCurrencies());

Debugger.Break();