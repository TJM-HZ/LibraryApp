﻿using LibraryApp.Products.ProductBuilders;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookBuilder bb = BookBuilder.GetInstance();
            GlobalLibrary glib = GlobalLibrary.GetInstance();

            // Creating some books by default
            glib.addBook(
                bb
                .Title("Design Patterns: Elements of Reusable Object-Oriented Software")
                .Author("The Gang of Four")
                .Country("United States")
                .Publisher("Addison-Wesley")
                .PrintLength(395)
                .Isbn10("0201633612")
                .Build()
            );

            glib.addBook(
                bb
                .Title("C# in Depth: Fourth Edition")
                .Author("Jon Skeet")
                .Country("United States")
                .Language("English")
                .Publisher("Manning")
                .PrintLength(528)
                .Isbn10("1617294535")
                .Isbn13("978-1617294532")
                .Build()
            );

            glib.addBook(
                bb
                .Title("Masters of Doom")
                .Author("David Kushner")
                .Country("United States")
                .Language("English")
                .Publisher("Random House Trade Paperbacks")
                .PrintLength(368)
                .Isbn10("0812972153")
                .Isbn13("978-0812972153")
                .Build()
            );

            glib.addBook(
                bb
                .Title("Het is oorlog maar niemand die het ziet")
                .Author("Huib Modderkolk")
                .Country("Nederland")
                .Language("Dutch")
                .Publisher("Podium")
                .PrintLength(368)
                .Isbn13("978-9463811460")
                .Build()
            );


            App App = new App();
        }


    }
}