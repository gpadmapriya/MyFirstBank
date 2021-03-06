﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyFirstBank;

namespace MyFirstBankUI.Controllers
{
    public class AccountsController : Controller
    {
        private BankDB db = new BankDB();

        // GET: Accounts
        [Authorize]
        public ActionResult Index()
        {
            var accounts = Bank.GetAllAccounts(HttpContext.User.Identity.Name);
            //return View(db.Accounts.ToList());
            return View(accounts);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,EmailAddress,AccountName,Balance,TypeOfAccount")] Account account)
        {
            if (ModelState.IsValid)
            {
                //db.Accounts.Add(account);
                //db.SaveChanges();
                Bank.CreateAccount(account.AccountName, account.EmailAddress, 0.0M, account.TypeOfAccount);
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailAddress,AccountNumber,AccountName,Balance,TypeOfAccount")] Account account)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(account).State = EntityState.Modified;
                //db.SaveChanges();
                Bank.EditAccount(account);
                return RedirectToAction("Index");
            }
            return View(account);
        }
        public ActionResult Transactions(int? id)
        {
            var transactions = Bank.GetAllTransactions(id.Value);
            return View(transactions);
        }

        //GET
        public ActionResult Deposit(int? id)
        {
            var account = Bank.GetAccountByAccountNumber(id.Value);
            return View(account);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(FormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["Amount"]);
            Bank.Deposit(accountNumber, amount);
            return RedirectToAction("Index");
        }

        //GET
        public ActionResult Withdraw(int? id)
        {
            var account = Bank.GetAccountByAccountNumber(id.Value);
            return View(account);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(FormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["Amount"]);
            Bank.Withdraw(accountNumber, amount);
            return RedirectToAction("Index");
        }
        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
