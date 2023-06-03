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

        public ExpenseDTO GetExpenseByUserRefId(int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated GetExpenseByUserRefId");
                var expense = _dbContext.Expenses.FirstOrDefault(e => e.UserRefId == userRefId);

                if (expense == null)
                    return null;

                var expenseDto = new ExpenseDTO
                {
                    ExpenseId = expense.ExpenseId,
                    UserRefId = expense.UserRefId,
                    ExpenseAmt = expense.ExpenseAmt,
                    Categories = expense.Categories,
                    Particulars = expense.Particulars,
                    UpdatedDate = expense.UpdatedDate
                };

                return expenseDto;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it
                _logger.LogError("Error Occured in GetExpenseByUserRefId");
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
