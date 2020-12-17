using System;
using System.Linq;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
  public class Scheduler : IScheduler
  {
    private int _amount;
    private int _durationInMonths;
    private float _annualInterest;
    private int _payoffsPerYear;
    private double _monthlyPayment;
    public Schedule CreateSchedule(LoanApplication paybackData)
    {
      _amount = paybackData.Amount;
      _durationInMonths = paybackData.DurationInMonths;
      _annualInterest = paybackData.AnnualInterest;
      _payoffsPerYear = paybackData.PayoffsPerYear;

      _monthlyPayment = GetMonthlyPayment();

      ScheduleRow[] scheduleRows = GetScheduleRows();

      float totalToPay = (float)(scheduleRows
        .Select(row => row.Payment)
        .Aggregate(0.0, (total, next) => total += next));
      float totalInterestToPay = (float)(scheduleRows
        .Select(row => row.Interest)
        .Aggregate(0.0, (total, next) => total += next));


      return new Schedule
      {
        Title = "Example Calculation",
        ScheduleTable = scheduleRows,
        TotalToPay = totalToPay,
        TotalInterestToPay = totalInterestToPay,
        Application = paybackData
      };
    }

    private double GetMonthlyPayment()
    {
      double factor = (1 + (_annualInterest * 0.01) / _payoffsPerYear);
      return (_amount * Math.Pow(factor, _durationInMonths) * (factor - 1)) / (Math.Pow(factor, _durationInMonths) - 1);
    }

    private ScheduleRow[] GetScheduleRows()
    {
      ScheduleRow[] schedule = new ScheduleRow[_durationInMonths];
      

      for (int i = 0; i < _durationInMonths; i++)
      {
        int monthNo = i + 1;

        double previousBalance = monthNo == 1 ? _amount : schedule[i - 1].Balance;
        double interest = GetInterestForGivenBalance(previousBalance);
        string dateString = GetPayoffDateForGivenMonthNo(monthNo);
        
        schedule[i] = new ScheduleRow{
          MonthNo = monthNo,
          Payment = _monthlyPayment,
          Interest = interest,
          Principal = _monthlyPayment - interest,
          Balance = previousBalance - _monthlyPayment + interest,
          Date = dateString
        };
      }

      foreach (var row in schedule)
      {
        row.Payment = Math.Round(row.Payment, 2);
        row.Interest = Math.Round(row.Interest, 2);
        row.Principal = Math.Round(row.Principal, 2);
        row.Balance = Math.Round(row.Balance, 2);
      }

      return schedule;
    }

    private double GetInterestForGivenBalance(double balance)
    {
      return balance * _annualInterest * 0.01 / 12;
    }

    string GetPayoffDateForGivenMonthNo(int monthNo)
    {
      return DateTime.Now.AddMonths(monthNo).ToShortDateString();
    }
  
  }
}