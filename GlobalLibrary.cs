using LibraryApp.Products.ProductBuilders;
using LibraryApp.Products.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class GlobalLibrary
    {
        public List<Book> Books { get; private set; } = new List<Book>();
        public List<ProductBundle> Bundles { get; private set; } = new List<ProductBundle>();

        private static GlobalLibrary _instance;
        private static readonly object Lock = new object();

        public static GlobalLibrary GetInstance()
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new GlobalLibrary();
                    }
                }
            }
            return _instance;
        }

        // Methods for BOOKS
        public void addBook(Book book) { this.Books.Add(book); }

        public void removeBook(Book book) { this.Books.Remove(book); }


        // Methods for BUNDLES
        public void addBundle(ProductBundle bundle) { this.Bundles.Add(bundle); }

        public void removeBundle(ProductBundle bundle) { this.Bundles.Remove(bundle); }
    }
}
