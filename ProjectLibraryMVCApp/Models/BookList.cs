using System.ComponentModel.DataAnnotations;

namespace ProjectLibraryMVCApp.Models
{
    public class BookList
    {
        public int BookId { get; set; }
        
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int YearOfPublication { get; set; }
        [Required]
        public int TotalQuantity { get; set; }
        [Required]
        public int AvailableQuantity { get; set; }
    }
}
