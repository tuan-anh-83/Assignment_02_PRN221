using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;

namespace Repository
{
    public interface IAccountRepository
    {
        BookManagementMember GetBookById(string id);
        public List<BookManagementMember> GetListAccount();

        public void addBookAccount(BookManagementMember accountBook);

        public void deleteBookAccount(string id);
    }
}
