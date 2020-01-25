using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Policy
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // based in percentages.
        public int CoverageType { get; set; }

        public DateTime EffectiveDate { get; set; }

        // It is based on months.
        public int CoveragePeriod { get; set; }

        public decimal Price { get; set; }

        public RiskType Risktype { get; set; }
    }
}
