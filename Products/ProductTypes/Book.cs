using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductTypes
{
    class Book : Product
    {
        private string title;
        private string printLength;
        private string language;

        private string? author;
        private string? publisher;
        private DateTime? publicationDate;
        private string? genre;
        private string? isbn10;
        private string? isbn13;

        private Book(string title, string printLength, string language, string? author, string? publisher, DateTime? publicationDate, string? genre, string? isbn10, string? isbn13)
        {
            this.title = title;
            this.printLength = printLength;
            this.language = language;
            this.author = author;
            this.publisher = publisher;
            this.publicationDate = publicationDate;
            this.genre = genre;
            this.isbn10 = isbn10;
            this.isbn13 = isbn13;
        }
    }
}
