using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnbRates.Model
{
	public record ExchangeRate
	{
		[Key]
		public int Id { get; init; }
		
		public DateTime Day { get; set; }

		public Currency Currency { get; set; }
		public int CurrencyId { get; set; }

		public decimal Rate { get; set; }
	}
}
