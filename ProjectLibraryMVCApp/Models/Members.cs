using System;

namespace ProjectLibraryMVCApp.Models
{
    public class Members
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? MemberSince { get; set; }
    }
}
