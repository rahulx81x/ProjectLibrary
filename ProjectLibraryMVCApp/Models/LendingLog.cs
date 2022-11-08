using System;

namespace ProjectLibraryMVCApp.Models
{
    public class LendingLog
    {
        public int TransactId { get; set; }
        public int? MemberId { get; set; }
        public int? BookId { get; set; }
        public DateTime BorrowedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
    }
}
