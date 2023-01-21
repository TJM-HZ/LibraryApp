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

        private string? _author;
        private string? _illustrator;
        private string? _publisher;

        private string? _language;

        private string? _country;

        private int? _printLength;

        private string? _isbn10;
        private string? _isbn13;

        private BookBuilder() 
        { 
            this.Reset(); 
        }

        private static BookBuilder _instance;

        private static readonly object Lock = new object();

        public static BookBuilder GetInstance()
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BookBuilder();
                    }
                }
            }
            return _instance;
        }

        public BookBuilder Title(string title)
        {
            this._title = title;
            return this;
        }

        public BookBuilder State(ProductState state) {
            this._state = state;
            return this;        
        }

        public BookBuilder Author(string author)
        {
            this._author = author;
            return this;
        }
        public BookBuilder Illustrator(string illustrator)
        {
            this._illustrator = illustrator;
            return this;
        }

        public BookBuilder Publisher(string publisher)
        {
            this._publisher = publisher;
            return this;
        }

        public BookBuilder Language(string language)
        {
            this._language = language;
            return this;
        }

        public BookBuilder Country(string country)
        {
            this._country = country;
            return this;
        }

        public BookBuilder PrintLength(int printLength)
        {
            this._printLength = printLength;
            return this;
        }

        public BookBuilder Isbn10(string isbn10)
        {
            this._isbn10 = isbn10;
            return this;
        }

        public BookBuilder Isbn13(string isbn13)
        {
            this._isbn13 = isbn13;
            return this;
        }

        public void Reset()
        {
            this._title = null;
            this._author = null;
            this._illustrator = null;
            this._publisher=null;
            this._language = null;
            this._country = null;
            this._printLength = null;
            this._isbn10 = null;
            this._isbn13 = null;
        }

        public Book Build()
        {
            if(this._title== null)
            {
                this._title = "LIBRARY ERROR: NO TITLE FOUND";
            }
            Book result = new Book(this._title, this._state, this._author, this._illustrator, this._publisher, this._language, this._country, this._printLength, this._isbn10, this._isbn13);
            this.Reset();
            return result;
        }


    }
}
