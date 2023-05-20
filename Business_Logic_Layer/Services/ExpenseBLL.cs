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
            var res = _expenseRepo.CreateExpense(expenseDto);
            return res;
        }
        public ExpenseDTO GetExpenseByUserRefId(int userRefId)
        {
            var res = _expenseRepo.GetExpenseByUserRefId(userRefId);
            return res;
        }
        public bool UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto)
        {
            var res = _expenseRepo.UpdateExpense(expenseId, userRefId, expenseDto);
            return res;
        }
        public bool DeleteExpense(int userRefId, int expenseId)
        {
            var res = _expenseRepo.DeleteExpense(userRefId,expenseId);
            return res;
        }

        

    }
}
