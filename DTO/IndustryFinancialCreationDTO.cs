using System.Collections.Generic;
using HeshmastNews.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace StatisticsApp.DTO
{
    public class IndustryFinancialCreationDTO
    {
        public double MaxSalary { get; set; }
        public double MinSalary { get; set; }
        public double AverageSalary { get; set; }
        public double Exempt { get; set; }
        public bool isExemptTax { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> UtmId { get; set; }
    }
}