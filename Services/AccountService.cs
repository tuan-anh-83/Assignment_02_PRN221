using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;
using Repository;

namespace Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;

        public AccountService()
        {
            accountRepository = new AccountRepository();
        }

        public void addBookAccount(BookManagementMember accountBook)
        {
            accountRepository.addBookAccount(accountBook);
        }

        public BookManagementMember GetBookById(string id)
        {
            return accountRepository.GetBookById(id);
        }

        public List<BookManagementMember> GetListAccount()
        {
            return accountRepository.GetListAccount();
        }

    }
}
