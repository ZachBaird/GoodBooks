using System;

namespace GoodBooks.Data.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Updated { get; set; }
        public string ReviewAuthor { get; set; }
        public string ReviewContent { get; set; }

        public Book Book { get; set; }
    }
}
