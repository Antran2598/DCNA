using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Repository;
using BookEccommerce_Admin.Models;

namespace BussinessLogicLayer_BLL
{
    public class AccountManagement
    {
        AccountRepository accountRepository = new AccountRepository();
        public bool checkLogin(string userName, string password)
        {
            return accountRepository.CheckLogin(userName, password);
        }
    }
}
