using LibraryApp.Products.ProductFSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductTypes
{
    class Book : Product
    {
        private string? author;
        private string? illustrator;
        private string? publisher;

        private string? language;

        private string? country;

        private DateTime? publicationDate;

        private int? printLength;

        private string? isbn10;
        private string? isbn13;

        public Book(string title, ProductState state, string? author, string? illustrator, string? publisher, string? language, string? country, DateTime? publicationDate, int? printLength, string? isbn10, string? isbn13)
        {
            this.Title = title;
            this.author = author;
            this.illustrator = illustrator;
            this.publisher = publisher;
            this.language = language;
            this.country = country;
            this.publicationDate = publicationDate;
            this.printLength = printLength;
            this.isbn10 = isbn10;
            this.isbn13 = isbn13;

            this.transitionTo(state);
        }
    }
}
