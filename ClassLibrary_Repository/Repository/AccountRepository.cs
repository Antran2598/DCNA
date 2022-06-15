
using BookEccommerce_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookEcommerceContext _context;
        public AccountRepository(BookEcommerceContext context)
        {
            _context = context;
        }
        public AccountRepository()
        {
            _context = new BookEcommerceContext();
        }
        public void AddAccount(Account newaccount)
        {
            try
            {
                _context.Accounts.Add(newaccount);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool DeleteAccount(int accountId)
        {
            Account account = _context.Accounts.Find(accountId);
            if (account != null)
            {
                try
                {
                    _context.Accounts.Remove(account);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public Account getAccount(int accountId)
        {
            Account account = _context.Accounts.Find(accountId);
            return account;
        }

        public List<Account> getAllAccount()
        {
            List<Account> accounts = _context.Accounts.ToList();
            return accounts;
        }

        public bool UpdateAccount(Account newaccount)
        {
            Account account = _context.Accounts.SingleOrDefault(account => account.Id.Equals(newaccount.Id));
            if (account != null)
            {
                try
                {
                    account.Address = newaccount.Address;
                    account.RoleId = newaccount.RoleId;
                    account.Fullname = newaccount.Fullname;
                    account.Password = newaccount.Password;
                    account.Phone = newaccount.Phone;
                    _context.Accounts.Update(newaccount);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public bool CheckLogin(string username, string password)
        {
            var q = from p in _context.Accounts
                    where p.Username == username
                    && p.Password == password
                    select p;
            if (q.Any())
            {

                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
