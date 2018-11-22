using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        [Display(Name="Book Title")]
        [RegularExpression(@"^[a-zA-Z''-'\s0-9]+$", ErrorMessage ="Please enter a valid book title. Accepted characters: A-Z, a-z, ', 0-9")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z\-'\s]+$", ErrorMessage = "Please enter a valid author name. Accepted characters: A-Z, a-z, ', -")]
        public string Author { get; set; }
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Please enter a valid year.")]
        public int? Year { get; set; }
        public int? BorrowerId { get; set; }

        public Borrower Borrower { get; set; }
    }
}
