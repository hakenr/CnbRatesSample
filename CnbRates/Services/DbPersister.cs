using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CnbRates.Model;
using Microsoft.Data.SqlClient;

namespace CnbRates.Services
{
	public class DbPersister
	{
		public async Task SaveCurrenciesAsync(IEnumerable<Currency> currencies)
		{
			using var conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=ExchangeRates;");

			await conn.OpenAsync();

			int id = 0;
			foreach (var currency in currencies)
			{
				id++;
				var cmd = new SqlCommand("INSERT INTO [Table](Id, Code, Name, Country) VALUES(@Id, @Code, @Name, @Country)");
				cmd.Connection = conn;
				cmd.Parameters.AddWithValue("@Id", id);
				cmd.Parameters.AddWithValue("@Code", currency.Code);
				cmd.Parameters.AddWithValue("@Name", currency.Name);
				cmd.Parameters.AddWithValue("@Country", currency.Country);
				await cmd.ExecuteNonQueryAsync();
			}

			await conn.CloseAsync();
		}
	}
}
