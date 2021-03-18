using System.Collections.Generic;

namespace StatisticsApp.Entity
{
    public class FinancialToIndustry
    {
        public int UtmId { get; set; }
        public int IndustryFinancialId { get; set; }
        public IndustryFinancial IndustryFinancial { get; set; }
        public UTM Utm { get; set; }
    }
}