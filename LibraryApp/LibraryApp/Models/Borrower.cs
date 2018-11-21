using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public partial class Borrower
    {
        public Borrower()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        [Display(Name="Borrower Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]+$", ErrorMessage = "Please only enter letters and apostrophes")]
        public string Name { get; set; }
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Please enter a valid age")]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9-]{11}$", ErrorMessage = "Please enter a phone number in the format XXX-XXX-XXX")]
        public string Phone { get; set; }

        public ICollection<Book> Book { get; set; }

        public Book bookNav { get; set; }

    }
}
