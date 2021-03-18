namespace StatisticsApp.DTO
{
    public class IndustryFinancialDTO
    {
        public int Id { get; set; }
        public double MaxSalary { get; set; }
        public double MinSalary { get; set; }
        public bool isExemptTax { get; set; }
        public double AverageSalary { get; set; }
        public double Exempt { get; set; }
    }
}