using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
using log4net.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class ExpenseBLL : IExpenseBLL
    {
        private readonly IExpenseRepository _expenseRepo;

        private readonly ILogger<ExpenseBLL> _logger;
        public ExpenseBLL(IExpenseRepository expenseRepo, ILogger<ExpenseBLL> logger)
        {
            _expenseRepo = expenseRepo;
            _logger = logger;
        }

        public ExpenseDTO CreateExpense(ExpenseDTO expenseDto)
        {
            try
            {
                _logger.LogInformation("Initiated CreateExpense");
                var res = _expenseRepo.CreateExpense(expenseDto);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured in CreateExpense");
                throw new ArgumentException("An error occurred while Creating");
            }
        }

        public List<ExpenseDTO> GetExpensesByUserRefId(int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated GetExpenseByUserRefId");
                var res = _expenseRepo.GetExpensesByUserRefId(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured in GetExpenseByUserRefId");
                throw new ArgumentException("An error occurred while Getting the expense");
            }
        }

        public bool UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto)
        {
            try
            {
                _logger.LogInformation("Initiated UpdateExpense");
                var res = _expenseRepo.UpdateExpense(expenseId, userRefId, expenseDto);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured in UpdateExpense");
                throw new ArgumentException("An error occurred while updating expense");
            }
        }

        public bool DeleteExpense(int userRefId, int expenseId)
        {
            try
            {
                _logger.LogInformation("Initiated DeleteExpense");
                var res = _expenseRepo.DeleteExpense(userRefId, expenseId);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured in DeleteExpense");
                throw new ArgumentException("An error occurred while Deleting expenses");
            }
        }
    }
}
