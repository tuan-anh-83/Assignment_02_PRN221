using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;

namespace Services
{
    public interface IAccountService
    {
        BookManagementMember GetBookById(string id);

        public List<BookManagementMember> GetListAccount();

        public void addBookAccount(BookManagementMember accountBook);

        public void deleteBookAccount(string id);

        public void UpdateBookProfile(BookManagementMember bookaccount);
    }
}
