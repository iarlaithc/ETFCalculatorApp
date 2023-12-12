using ETFCalculatorApp.Enums;

namespace ETFCalculatorApp.Models
{
    public class CompoundingModel
    {
        public double StartingAmount { get; set; }

        public double RecurringInvestmentAmount { get; set; }

        public int TotalInvestmentDays { get; set; }

        public double ExpectedGrowthPercentage { get; set; }

        public CompoundingIntervalEnum RecurringInvestmentInterval { get; set; }

        public CompoundingIntervalEnum CompoundingInterval { get; set; }

        public int DeemedDisposal = (int)DeemedDisposalEnum.DeemedDisposalLength;


        public CompoundingModel() 
        {
            StartingAmount = 0;
            RecurringInvestmentAmount = 0;
            TotalInvestmentDays = 0;
            ExpectedGrowthPercentage = 0;
            RecurringInvestmentInterval = CompoundingIntervalEnum.Monthly;
            CompoundingInterval = CompoundingIntervalEnum.Monthly;
        }
    }
}
