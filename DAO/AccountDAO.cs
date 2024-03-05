using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Objects.Models;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        //private readonly BookManagementContext dBContext = null;
        public AccountDAO()
        {
            /*if (instance == null)
            {
                dBContext = new BookManagementContext();
            }*/

        }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public BookManagementMember GetBookById(String id)
        {
                var dBContext = new BookManagementContext();
            return dBContext.BookManagementMembers.SingleOrDefault(m => m.MemberId.Equals(id));
            
        }

        public List<BookManagementMember> GetListAccount()
        {
            var dBContext = new BookManagementContext();

            return dBContext.BookManagementMembers.ToList();
        }

        public void addBookAccount(BookManagementMember accountBook)
        {
            //truoc khi save thi:
            BookManagementMember account = GetBookById(accountBook.MemberId);
            if (account == null)
            {
                using (var dbContext = new BookManagementContext())
                {
                    dbContext.BookManagementMembers.Add(accountBook);
                    dbContext.SaveChanges();
                }
            }

        }

        public void deleteBookAccount(string id)
        {
            //truoc khi save thi:
            BookManagementMember book = GetBookById(id);
            if (book != null)
            {
                var dBContext = new BookManagementContext();
                dBContext.BookManagementMembers.Remove(book);
                dBContext.SaveChanges();
            }

        }
    }
}
