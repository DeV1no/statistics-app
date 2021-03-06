using System;
using System.Collections.Generic;
using StatisticsApp.Data;

namespace StatisticsApp.Entity
{
    public class UTM : IId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public double Lngitude { get; set; }
        public double Latitude { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<FinancialToIndustry> FinancialToIndustries { get; set; }
        public List<OficeToUtm> OficeToUtm { get; set; }

        public UTM()
        {
            this.UpdatedAt = DateTime.Today;
        }
    }
}