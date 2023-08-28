using Data_Access_Layer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IExpenseBLL
    {
        ExpenseDTO CreateExpense(ExpenseDTO expenseDto);
        List<ExpenseDTO> GetExpensesByUserRefId(int userRefId);
        bool UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto);
        bool DeleteExpense(int userRefId, int expenseId);
    }
}
