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
        protected List<Product> _products = new List<Product>();

        public ProductBundle(string title)
        {
            Title = title;
        }

        public virtual void transitionTo(ProductState state)
        {
            foreach (Product product in _products) { 
                product.transitionTo(state);
            }
        }

        public override void Add(Product product)
        {
            this._products.Add(product);
        }

        public override void Remove(Product product)
        {
            this._products.Remove(product);
        }

        public override void printDetails()
        {
            Console.WriteLine($"Bundle Name: {Title}");

            foreach (Product product in this._products)
            {
                product.printDetails();
            }
        }
    }
}
