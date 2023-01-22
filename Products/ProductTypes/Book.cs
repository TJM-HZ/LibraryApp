using LibraryApp.Products.ProductFSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductTypes
{
    public class Book : Product
    {
        // TODO: Maybe I should add auto-implemented accessors for these fields?

        public string? Author { get; private set; }
        private string? _illustrator;
        private string? _publisher;

        private string? _language;

        private string? _country;

        private int? _printLength;

        public string? Isbn10 { get; private set; }
        public string? Isbn13 { get; private set; }


    // TODO: Maybe the constructor can be cleaned up now that I have a Builder?
    public Book(string title,
            ProductState? state, 
            string? author, string? 
            illustrator, string? 
            publisher, string? 
            language, string? country, 
            int? printlength, 
            string? isbn10, 
            string? isbn13)
        {
            this.Title = title;

            if (state != null)
            {
                this.TransitionTo(state);
            } else
            {
                this.TransitionTo(new AvailableState());
            }


            this.Author = author;
            this._illustrator = illustrator;
            this._publisher = publisher;
            this._language = language;
            this._country = country;
            this._printLength = printlength;
            this.Isbn10 = isbn10;
            this.Isbn13 = isbn13;
        }

        public override void PrintDetails()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {this.Title}");
            Console.WriteLine($"Author: {this.Author}");
            Console.WriteLine($"Illustrator: {this._illustrator}");
            Console.WriteLine($"Publisher: {this._publisher}");
            Console.WriteLine($"Language: {this._language}");
            Console.WriteLine($"Country: {this._country}");
            Console.WriteLine($"Print Length: {this._printLength}");
            Console.WriteLine($"ISBN-10: {this.Isbn10}");
            Console.WriteLine($"ISBN-13: {this.Isbn13}");
            Console.WriteLine($"STATUS: {this.State.StateName.ToUpper()}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
