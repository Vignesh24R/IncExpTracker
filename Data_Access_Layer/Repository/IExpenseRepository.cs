using Data_Access_Layer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public interface IExpenseRepository
    {
        ExpenseDTO CreateExpense(ExpenseDTO expenseDto);
        ExpenseDTO GetExpenseByUserRefId(int userRefId);
        bool UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto);
        bool DeleteExpense(int userRefId, int expenseId);
    }
}
