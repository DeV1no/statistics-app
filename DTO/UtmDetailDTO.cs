using System.Collections.Generic;

namespace StatisticsApp.DTO
{
    public class UtmDetailDTO : UtmDTO
    {
        public List<IndustryFinancialDTO> IndustryFinancial { get; set; }
    }
}