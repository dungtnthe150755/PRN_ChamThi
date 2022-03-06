﻿using ChamThiDotnet5.Models;
using ChamThiWeb5.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChamThiDotnet5.DAO
{
    public class AccountDAO
    {
        AppDbContext DbContext = new AppDbContext();

        public int AddNewAccount(Account Account)
        {
            int n = 0;
            try
            {
                DbContext.Accounts.Add(Account);
                n = DbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex.InnerException;
            }
            DbContext = new AppDbContext();
            return n;

        }

        public List<Account> ReadAllAccount()
        {
            IQueryable<Account> Accounts = from a in DbContext.Accounts select a;
            return Accounts.ToList();

        }

        public Account ReadAAccount(int id)
        {
            Account Account = (from a in DbContext.Accounts where a.Id == id select a).FirstOrDefault();
            return Account;
        }

        // return false co nghia id khong ton tai
        public int UpdateAccount(int id, Account NewAccount)

        {
            int n = 0;
            Account Account = ReadAAccount(id);
            if (Account == null) return n;
            Account = NewAccount;


            try
            {
                n = DbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex.InnerException;
            }
            DbContext = new AppDbContext();
            return n;


        }
        public int DeleteAccount(int id)
        {
            int n = 0;
            Account Account = ReadAAccount(id);
            if (Account != null)
                DbContext.Accounts.Remove(Account);
            try
            {
                n = DbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex.InnerException;
            }
            DbContext = new AppDbContext();
            return n;

        }
    }
}
