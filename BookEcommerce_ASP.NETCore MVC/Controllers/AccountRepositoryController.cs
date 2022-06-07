using Microsoft.AspNetCore.Mvc;
using ClassLibrary_RepositoryDLL.Repository;

using System.Collections.Generic;
using BookEccommerce_Admin.Models;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    public class AccountRepositoryController : Controller
    {
        IAccountRepository _repository;

        public AccountRepositoryController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Account> GetAllAccount()
        {
            List<Account> accounts = _repository.getAllAccount();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            Account account = _repository.getAccount(id);
            return Ok(account);
        }

        [HttpPost]
        public ActionResult AddAccount([FromBody] Account newaccount)
        {
            _repository.AddAccount(newaccount);
            List<Account> accounts = _repository.getAllAccount();
            return Ok(accounts);
        }

        [HttpPut]
        public ActionResult UpdateAccount([FromBody] Account newaccount)
        {
            _repository.UpdateAccount(newaccount);
            return Ok(newaccount);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAccount(int id)
        {
            _repository.DeleteAccount(id);
            List<Account> accounts = _repository.getAllAccount();
            return Ok(accounts);
        }
    }
}
