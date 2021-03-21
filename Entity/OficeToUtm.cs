using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StatisticsApp.Data;

namespace StatisticsApp.Entity
{
    public class OficeToUtm
    {
        public int UtmId { get; set; }
        public int CentralOficeId { get; set; }
        public CentralOfice CentralOfice { get; set; }
        public UTM UTM { get; set; }
    }
}