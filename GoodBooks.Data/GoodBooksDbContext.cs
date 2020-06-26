using GoodBooks.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GoodBooks.Data
{
    public class GoodBooksDbContext : DbContext
    {
        public GoodBooksDbContext() { }
        public GoodBooksDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookReview> BookReviews { get; set; }
    }
}
