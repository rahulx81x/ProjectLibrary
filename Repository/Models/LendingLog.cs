using System;
using System.Collections.Generic;

namespace ProjectLibraryDAL.Models
{
    public partial class LendingLog
    {
        public int TransactId { get; set; }
        public int? MemberId { get; set; }
        public int? BookId { get; set; }
        public DateTime BorrowedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }

        public virtual BookList Book { get; set; }
        public virtual Members Member { get; set; }
    }
}
