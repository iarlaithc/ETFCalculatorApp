using ETFCalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETFCalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CompoundingModel m = new CompoundingModel();

            m.StartingAmount = 1000;
            m.RecurringInvestmentAmount = 500;
            m.ExpectedGrowthPercentage = 2; // 2%
            m.CompoundingInterval = Enums.ECompoundingInterval.Monthly;
            m.TotalInvestmentYears = 5;
            m.RecurringInvestmentInterval = Enums.ECompoundingInterval.Monthly;

            m.TotalResult = CalculateMainCompoundingEquation(m);
            return View(m);
        }

        public double CalculateMainCompoundingEquation(CompoundingModel m)
        {
            double principal = m.StartingAmount;
            double rate = m.ExpectedGrowthPercentage / 100;
            int time = m.TotalInvestmentYears * (int)m.CompoundingInterval;
            double interest = rate / (int)m.CompoundingInterval;
            double result = principal * Math.Pow((1 + interest), time);

            // If there's a recurring investment
            if (m.RecurringInvestmentAmount > 0)
            {
                double recurringInvestment = m.RecurringInvestmentAmount;
                int recurringTime = m.TotalInvestmentYears * (int)m.RecurringInvestmentInterval;
                for (int i = 0; i < recurringTime; i++)
                {
                    result += recurringInvestment * Math.Pow((1 + interest), (recurringTime - i));
                }
            }

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}