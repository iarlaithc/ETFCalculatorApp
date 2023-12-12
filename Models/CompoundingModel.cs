using ETFCalculatorApp.Enums;

namespace ETFCalculatorApp.Models
{
    public class CompoundingModel
    {
        public double StartingAmount { get; set; }

        public double RecurringInvestmentAmount { get; set; }

        public int TotalInvestmentYears { get; set; }

        public double ExpectedGrowthPercentage { get; set; }

        public ECompoundingInterval RecurringInvestmentInterval { get; set; }

        public ECompoundingInterval CompoundingInterval { get; set; }

        public double TotalResult { get; set; }

        public int DeemedDisposal = (int)EDeemedDisposal.DeemedDisposalLength;


        public CompoundingModel() 
        {
            StartingAmount = 0;
            RecurringInvestmentAmount = 0;
            TotalInvestmentYears = 0;
            ExpectedGrowthPercentage = 0;
            TotalResult = 0;
            RecurringInvestmentInterval = ECompoundingInterval.Monthly;
            CompoundingInterval = ECompoundingInterval.Monthly;
        }
    }
}
