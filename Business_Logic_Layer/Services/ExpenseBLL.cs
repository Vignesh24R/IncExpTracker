using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
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

        public ExpenseBLL(IExpenseRepository expenseRepo)
        {
            _expenseRepo = expenseRepo;
        }

        public ExpenseDTO CreateExpense(ExpenseDTO expenseDto)
        {
            try
            {
                var res = _expenseRepo.CreateExpense(expenseDto);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's requirements
                throw new ArgumentException("An error occurred while Creating");
            }
        }

        public ExpenseDTO GetExpenseByUserRefId(int userRefId)
        {
            try
            {
                var res = _expenseRepo.GetExpenseByUserRefId(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's requirements
                throw new ArgumentException("An error occurred while Getting the expense");
            }
        }

        public bool UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto)
        {
            try
            {
                var res = _expenseRepo.UpdateExpense(expenseId, userRefId, expenseDto);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's requirements
                throw new ArgumentException("An error occurred while updating expense");
            }
        }

        public bool DeleteExpense(int userRefId, int expenseId)
        {
            try
            {
                var res = _expenseRepo.DeleteExpense(userRefId, expenseId);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's requirements
                throw new ArgumentException("An error occurred while Deleting expenses");
            }
        }
    }
}
