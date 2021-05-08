using ExpenseManager.Areas.Identity.Data;
using ExpenseManager.Data;
using ExpenseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.DataBase
{
    //klasa odpowiedzialna za opis metod pobieranie, dodawanie nowych wydatków, aktyalizacja, usuwanie
    public class ExpenseRepository : IExpenseRepository  //klasa ExpenseRepository implementuje interfejs IExpenseRepository
    {
        private readonly ExpenseManagerDBContext _context;

        public ExpenseRepository(ExpenseManagerDBContext context)
        {
            _context = context;
        }
        public ExpenseModel Get(int ExpenseId)
            => _context.Expenses.SingleOrDefault(x => x.ExpenseId == ExpenseId);

        public IQueryable<ExpenseModel> GetAllActive()
            => _context.Expenses;

        public IQueryable<ExpenseModel> GetAllActivePerUser(string UserId)
            => _context.Expenses.Where(x => x.UserId == UserId);

        public void Add(ExpenseModel expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public void Update(int ExpenseId, ExpenseModel expense)
        {
            var result = _context.Expenses.SingleOrDefault(x => x.ExpenseId == ExpenseId);
            if (result != null)
            {
                result.Name = expense.Name;
                result.Description = expense.Description;
                result.Amount = expense.Amount;
                result.Date = expense.Date;
                result.Category = expense.Category;
                result.UserId = expense.UserId;
                _context.SaveChanges();
            }
        }

        public void Delete(int ExpenseId)
        {
            var result = _context.Expenses.SingleOrDefault(x => x.ExpenseId == ExpenseId);
            if (result != null)
            {
                _context.Expenses.Remove(result);
                _context.SaveChanges();
            }
        }

    }
}
