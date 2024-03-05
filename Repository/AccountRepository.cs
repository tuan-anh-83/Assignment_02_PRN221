using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Objects.Models;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public BookManagementMember GetBookById(string id) => AccountDAO.Instance.GetBookById(id);

        public List<BookManagementMember> GetListAccount() => AccountDAO.Instance.GetListAccount();

        public void addBookAccount(BookManagementMember accountBook) => AccountDAO.Instance.addBookAccount(accountBook);


    }
}
