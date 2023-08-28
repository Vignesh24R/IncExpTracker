using Data_Access_Layer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IExpenseRepository
    {
        ExpenseDTO CreateExpense(ExpenseDTO expenseDto);
        List<ExpenseDTO> GetExpensesByUserRefId(int userRefId);
        bool UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto);
        bool DeleteExpense(int userRefId, int expenseId);
    }
}
