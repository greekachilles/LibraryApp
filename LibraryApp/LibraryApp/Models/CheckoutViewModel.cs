using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class CheckoutViewModel
    {
        public int? BookId { get; set; }
        public int? BorrowerId { get; set; }

        public string BookName { get; set; }
        public string BorrowerName { get; set; }
    }
}
