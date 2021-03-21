using System.Collections.Generic;
using HeshmastNews.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace StatisticsApp.DTO
{
    public class CentralOficeCreationDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public double Lngitude { get; set; }
        public double Latitude { get; set; }
        public int PostalCode { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> UtmId { get; set; }
    }
}