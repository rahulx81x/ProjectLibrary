using System;
using System.Collections.Generic;

namespace ProjectLibraryDAL.Models
{
    public partial class Members
    {
        public Members()
        {
            LendingLog = new HashSet<LendingLog>();
        }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? MemberSince { get; set; }

        public virtual ICollection<LendingLog> LendingLog { get; set; }
    }
}
