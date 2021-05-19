using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FutureValueCalculator.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage ="Please enter a monthly investment")] //ERROR MESSAGE TO SHOW IF THE FIELD IS EMPTY
        [Range(1,500,ErrorMessage = "Monthly investment must be between 1 and 500")] //ERROR MESSAGE TO SHOW IF THE INSERTED VALUE IS GREATER OR MINUS THAN THE RANGE
        public decimal? MonthlyInvestment { get; set; } //AMOUNT OF MONTHLY PAYMENT..... QUESTION MARK TO MAKE THE PROPERTY NULLABLE AND SHOW THE MESSAGE IN THE PAGE

        [Required(ErrorMessage = "Please enter a yearly investment rate")] //ERROR MESSAGE TO SHOW IF THE FIELD IS EMPTY
        [Range(0.1, 10.0, ErrorMessage = "Yearly invest rate must be between 0.1 and 10.0")] //ERROR MESSAGE TO SHOW IF THE INSERTED VALUE IS GREATER OR MINUS THAN THE RANGE
        public decimal? YearlyInterestRate { get; set; } //PERCENTAGE OF INTEREST RATE..... QUESTION MARK TO MAKE THE PROPERTY NULLABLE AND SHOW THE MESSAGE IN THE PAGE

        [Required(ErrorMessage = "Please enter a number of years")] //ERROR MESSAGE TO SHOW IF THE FIELD IS EMPTY
        [Range(1, 50, ErrorMessage = "Number of years must be between 1 and 50")] //ERROR MESSAGE TO SHOW IF THE INSERTED VALUE IS GREATER OR MINUS THAN THE RANGE
        public int? Years { get; set; } //TOTAL OF YEARS..... QUESTION MARK TO MAKE THE PROPERTY NULLABLE AND SHOW THE MESSAGE IN THE PAGE

        public decimal Calculate() //CALCULATION METHOD
        {
            int months = Years.Value * 12;
            decimal monthlyInterestRate = YearlyInterestRate.Value / 12 / 100; 
            decimal futureValue = 0; 

            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment.Value) * (1 + monthlyInterestRate);
            }
            return futureValue;
        }
    }
}
