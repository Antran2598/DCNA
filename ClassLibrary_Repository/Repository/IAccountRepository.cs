using BookEccommerce_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary_RepositoryDLL.Repository
{
    public interface IAccountRepository
    {
        List<Account> getAllAccount();
        void AddAccount(Account newaccount);
        bool UpdateAccount(Account newaccount);
        bool DeleteAccount(int accountId);
        Account getAccount(int accountId);
    }
}
