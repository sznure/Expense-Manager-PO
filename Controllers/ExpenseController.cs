using ExpenseManager.DataBase;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ExpenseManager.Models;

namespace ExpenseManager.Controllers
{
    [Authorize] // dostęp tylko po zalogowaniu się
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: Expense
        public ActionResult IndexAll()
        {
            return View(_expenseRepository.GetAllActive());              
        }

        public ActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
           
            return View(_expenseRepository.GetAllActivePerUser(userId));

        }

        // GET: Expense/Details/5
        public ActionResult Details(int id)
        {
            return View(_expenseRepository.Get(id)); // wyszukuje element o podanym id
        }

        // GET: Expense/Create
        public ActionResult Create()                //bezparametrowa metoda create
        {
            return View(new ExpenseModel());        //przekzuję do widoku nowy parametr ExpenseModel
        }

        // POST: Expense/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseModel expenseModel) //typ ExpenseModel parametr expenseModel
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            expenseModel.UserId = userId;

            _expenseRepository.Add(expenseModel);

            return RedirectToAction(nameof(Index));
            
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_expenseRepository.Get(id));
        }

        // POST: Expense/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExpenseModel expenseModel)                 //typ ExpenseModel typ expenseModel
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            expenseModel.UserId = userId;

            _expenseRepository.Update(id, expenseModel);

            return RedirectToAction(nameof(Index));
            
        }

        // GET: Expense/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_expenseRepository.Get(id));
        }

        // POST: Expense /Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ExpenseModel expenseModel)
        {
            _expenseRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
            
    }
}
