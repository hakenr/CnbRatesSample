using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnbRates.Model
{
	public record ExchangeRate
	{
		public DateTime Day { get; set; }
		public Currency Currency { get; set; }
		public decimal Rate { get; set; }
	}
}
