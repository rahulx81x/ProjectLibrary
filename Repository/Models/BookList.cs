using System;
using System.Collections.Generic;

namespace ProjectLibraryDAL.Models
{
    public partial class BookList
    {
        public BookList()
        {
            LendingLog = new HashSet<LendingLog>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int YearOfPublication { get; set; }
        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; }

        public virtual ICollection<LendingLog> LendingLog { get; set; }
    }
}
