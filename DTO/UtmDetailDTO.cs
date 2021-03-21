using System.Collections.Generic;
using StatisticsApp.Entity;

namespace StatisticsApp.DTO
{
    public class UtmDetailDTO : UtmDTO
    {
        public List<IndustryFinancialDTO> IndustryFinancial { get; set; }
        public List<CentralOficeDTO> CentralOfice { get; set; }
    }
}