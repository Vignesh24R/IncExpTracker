using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data_Access_Layer.Models.DTO;
using Data_Access_Layer.Interfaces;
using Microsoft.Extensions.Logging;

namespace Data_Access_Layer.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _dbContext;

        private readonly ILogger<ExpenseRepository> _logger;
        public ExpenseRepository(AppDbContext dbContext, ILogger<ExpenseRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public ExpenseDTO CreateExpense(ExpenseDTO expenseDto)
        {
            try
            {
                _logger.LogInformation("Initiated CreateExpense");
                var expense = new Expense
                {
                    UserRefId = expenseDto.UserRefId,
                    ExpenseAmt = expenseDto.ExpenseAmt,
                    Categories = expenseDto.Categories,
                    Particulars = expenseDto.Particulars,
                    UpdatedDate = DateTime.Now
                };

                _dbContext.Expenses.Add(expense);
                _dbContext.SaveChanges();

                expenseDto.ExpenseId = expense.ExpenseId; // Update the DTO with the generated ExpenseId

                return expenseDto;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it
                _logger.LogError("Error Occured in CreateExpense");
                throw;
            }
        }

        public List<ExpenseDTO> GetExpensesByUserRefId(int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated GetExpensesByUserRefId");
                var expenses = _dbContext.Expenses
                    .Where(e => e.UserRefId == userRefId)
                    .ToList();

                var expenseDTOs = expenses.Select(e => new ExpenseDTO
                {
                    ExpenseId = e.ExpenseId,
                    UserRefId = e.UserRefId,
                    ExpenseAmt = e.ExpenseAmt,
                    Categories = e.Categories,
                    Particulars = e.Particulars,
                    UpdatedDate = e.UpdatedDate
                }).ToList();

                return expenseDTOs;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it
                _logger.LogError("Error Occurred in GetExpensesByUserRefId");
                throw;
            }
        }

        public bool UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto)
        {
            try
            {
                _logger.LogInformation("Initiated UpdateExpense");
                var expense = _dbContext.Expenses.FirstOrDefault(e => e.ExpenseId == expenseId && e.UserRefId == userRefId);

                if (expense == null)
                    return false;

                expense.ExpenseAmt = expenseDto.ExpenseAmt;
                expense.Categories = expenseDto.Categories;
                expense.Particulars = expenseDto.Particulars;
                expense.UpdatedDate = DateTime.Now;

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it
                _logger.LogError("Error Occured in UpdateExpense");
                throw;
            }
        }

        public bool DeleteExpense(int userRefId, int expenseId)
        {
            try
            {
                _logger.LogInformation("Initiated DeleteExpense");
                var expense = _dbContext.Expenses.FirstOrDefault(e => e.ExpenseId == expenseId && e.UserRefId == userRefId);

                if (expense == null)
                    return false;

                _dbContext.Expenses.Remove(expense);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured in DeleteExpense");
                throw;
            }
        }
    }
}
