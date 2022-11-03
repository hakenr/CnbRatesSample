using System.ComponentModel.DataAnnotations;

namespace CnbRates.Model
{
	public class Currency
	{
		[Key]
		public int Id { get; init; }
		public string Code { get; init; }
		public string Country { get; init; }
		public string Name { get; init; }
	}
}