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
        private string? _title;

        private ProductState? _state;

        private string? author;
        private string? _illustrator;
        private string? _publisher;

        private string? _language;

        private string? _country;

        private int? _printLength;

        private string? _isbn10;
        private string? _isbn13;

        private BookBuilder() 
        { 
            this.reset(); 
        }

        private static BookBuilder _instance;

        private static readonly object _lock = new object();

        public static BookBuilder GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BookBuilder();
                    }
                }
            }
            return _instance;
        }

        public BookBuilder setTitle(string title)
        {
            this._title = title;
            return this;
        }

        public BookBuilder setState(ProductState state) {
            this._state = state;
            return this;        
        }

        public BookBuilder setAuthor(string author)
        {
            this.author = author;
            return this;
        }
        public BookBuilder setIllustrator(string illustrator)
        {
            this._illustrator = illustrator;
            return this;
        }

        public BookBuilder setPublisher(string publisher)
        {
            this._publisher = publisher;
            return this;
        }

        public BookBuilder setLanguage(string language)
        {
            this._language = language;
            return this;
        }

        public BookBuilder setCountry(string country)
        {
            this._country = country;
            return this;
        }

        public BookBuilder setPrintLength(int printLength)
        {
            this._printLength = printLength;
            return this;
        }

        private BookBuilder setISBN10(string isbn10)
        {
            this._isbn10 = isbn10;
            return this;
        }

        private BookBuilder setISBN13(string isbn13)
        {
            this._isbn13 = isbn13;
            return this;
        }

        public void reset()
        {
            this._title = null;
            this.author = null;
            this._illustrator = null;
            this._publisher=null;
            this._language = null;
            this._country = null;
            this._printLength = null;
            this._isbn10 = null;
            this._isbn13 = null;
        }

        public Book build()
        {
            if(this._title== null)
            {
                this._title = "LIBRARY ERROR: NO TITLE FOUND";
            }
            Book result = new Book(this._title, this._state, this.author, this._illustrator, this._publisher, this._language, this._country, this._printLength, this._isbn10, this._isbn13);
            this.reset();
            return result;
        }


    }
}
