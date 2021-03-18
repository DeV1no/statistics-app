using StatisticsApp.Data;

namespace StatisticsApp.Entity
{
    public class TaxRate : IId
    {
        public int Id { get; set; }
        public double TaxRateCount { get; set; }
    }
}