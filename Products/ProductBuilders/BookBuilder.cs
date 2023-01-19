using LibraryApp.Products.ProductFSM;
using LibraryApp.Products.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductBuilders
{
    public class BookBuilder
    {
        private string? title;

        private ProductState? state;

        private string? author;
        private string? illustrator;
        private string? publisher;

        private string? language;

        private string? country;

        private int? printLength;

        private string? isbn10;
        private string? isbn13;

        public BookBuilder()
        {
            this.reset();
        }
        public BookBuilder setTitle(string title)
        {
            this.title = title;
            return this;
        }

        public BookBuilder setState(ProductState state) {
            this.state = state;
            return this;        
        }

        public BookBuilder setAuthor(string author)
        {
            this.author = author;
            return this;
        }
        public BookBuilder setIllustrator(string illustrator)
        {
            this.illustrator = illustrator;
            return this;
        }

        public BookBuilder setPublisher(string publisher)
        {
            this.publisher = publisher;
            return this;
        }

        public BookBuilder setLanguage(string language)
        {
            this.language = language;
            return this;
        }

        public BookBuilder setCountry(string country)
        {
            this.country = country;
            return this;
        }

        public BookBuilder setPrintLength(int printLength)
        {
            this.printLength = printLength;
            return this;
        }

        private BookBuilder setISBN10(string isbn10)
        {
            this.isbn10 = isbn10;
            return this;
        }

        private BookBuilder setISBN13(string isbn13)
        {
            this.isbn13 = isbn13;
            return this;
        }

        public void reset()
        {
            this.title = null;
            this.author = null;
            this.illustrator = null;
            this.publisher=null;
            this.language = null;
            this.country = null;
            this.printLength = null;
            this.isbn10 = null;
            this.isbn13 = null;
        }

        public Book build()
        {
            Book result = new Book(this.title, this.state, this.author, this.illustrator, this.publisher, this.language, this.country, this.printLength, this.isbn10, this.isbn13);
            this.reset();
            return result;
        }


    }
}
