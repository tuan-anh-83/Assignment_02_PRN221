using System;
using System.Collections.Generic;

namespace Objects.Models
{
    public partial class BookBorrow
    {
        public string BookBorrowId { get; set; } = null!;
        public string BookId { get; set; } = null!;
        public string MemberId { get; set; } = null!;
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual BookManagementMember Member { get; set; } = null!;
    }
}
