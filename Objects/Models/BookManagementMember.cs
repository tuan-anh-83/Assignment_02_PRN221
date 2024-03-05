using System;
using System.Collections.Generic;

namespace Objects.Models
{
    public partial class BookManagementMember
    {
        public BookManagementMember()
        {
            BookBorrows = new HashSet<BookBorrow>();
        }

        public string MemberId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int MemberRole { get; set; }

        public virtual ICollection<BookBorrow> BookBorrows { get; set; }
    }
}
