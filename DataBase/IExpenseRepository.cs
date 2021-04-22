using ExpenseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.DataBase
{
    public interface IExpenseRepository
    {
        ExpenseModel Get(int ExpenseId);    //metoda Get zwracajaca ExpenseModel i przyjmująca ExpenseId typu int
        IQueryable<ExpenseModel> GetAllActive();  //IQueryable pobiera dane które spełniają nasze warunki, nie po kolei

        void Add(ExpenseModel expense);     //metoda add przyjmująca parametr expense typu ExpenseModel, nie zwraca żadnych wartości

        void Update(int ExpenseId, ExpenseModel expense); //metoda update przyjmująca parametry

        void Delete(int ExpenseId);

    }
}
