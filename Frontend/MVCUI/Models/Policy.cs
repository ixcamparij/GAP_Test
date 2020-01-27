using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Models
{
    public class Policy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // based in percentages.
        public  int CoverageType { get; set; }

        public DateTime EffectiveDate { get; set; }

        // It is based on months.
        public int CoveragePeriod { get; set; }

        public decimal Price { get; set; }

        public RiskType Risktype { get; set; }
    }
}