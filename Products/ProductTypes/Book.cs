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
        private string? author;
        private string? illustrator;
        private string? publisher;

        private string? language;

        private string? country;

        private int? printLength;

        private string? isbn10;
        private string? isbn13;

        public Book(string title, ProductState state, string? author, string? illustrator, string? publisher, string? language, string? country, int? printlength, string? isbn10, string? isbn13)
        {
            this.Title = title;
            this.author = author;
            this.illustrator = illustrator;
            this.publisher = publisher;
            this.language = language;
            this.country = country;
            this.printLength = printlength;
            this.isbn10 = isbn10;
            this.isbn13 = isbn13;

            this.transitionTo(state);
        }

        public override void printDetails()
        {
            Console.WriteLine($"Title: {this.Title}");
            Console.WriteLine($"Author: {this.author}");
            Console.WriteLine($"Illustrator: {this.illustrator}");
            Console.WriteLine($"Publisher: {this.publisher}");
            Console.WriteLine($"Language: {this.language}");
            Console.WriteLine($"Country: {this.country}");
            Console.WriteLine($"printLength: {this.printLength}");
            Console.WriteLine($"ISBN-10: {this.isbn10}");
            Console.WriteLine($"ISBN-13: {this.isbn13}");
        }
    }
}
