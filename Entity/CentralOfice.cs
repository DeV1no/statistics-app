using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StatisticsApp.Data;

namespace StatisticsApp.Entity
{
    public class CentralOfice : IId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public double Lngitude { get; set; }
        public double Latitude { get; set; }
        public List<OficeToUtm> OficeToUtm { get; set; }

    }
}