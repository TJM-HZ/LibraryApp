using LibraryApp.Products.ProductFSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products
{
    class ProductBundle : Product
    {
        protected List<Product> Products = new List<Product>();

        public ProductBundle(string title)
        {
            Title = title;
        }

        public override void TransitionTo(ProductState state)
        {
            foreach (Product product in Products) { 
                product.TransitionTo(state);
            }
        }

        public override void Add(Product product)
        {
            this.Products.Add(product);
        }

        public override void Remove(Product product)
        {
            this.Products.Remove(product);
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Bundle Name: {Title}");

            foreach (Product product in this.Products)
            {
                product.PrintDetails();
            }
        }
    }
}
