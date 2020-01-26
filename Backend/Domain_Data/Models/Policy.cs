using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Data.Models
{
    public class Policy
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        // based in percentages.
        public virtual int CoverageType { get; set; }

        public virtual DateTime EffectiveDate { get; set; }

        // It is based on months.
        public virtual int CoveragePeriod { get; set; }

        public virtual decimal Price { get; set; }

        public virtual RiskType Risktype { get; set; }
    }
}
