using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StatisticsApp.Data;

namespace StatisticsApp.Entity
{
    public class IndustryFinancial : IId
    {
        public int Id { get; set; }
        public double MaxSalary { get; set; }
        public double MinSalary { get; set; }
        public bool isExemptTax { get; set; }
        public double AverageSalary { get; set; }
        public double Exempt { get; set; }
        public List<FinancialToIndustry> FinancialToIndustries { get; set; }
    }
}