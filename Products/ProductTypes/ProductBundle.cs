﻿using LibraryApp.Products.ProductFSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductTypes
{
    public class ProductBundle : Product
    {
        protected List<Product> Products = new List<Product>();

        public ProductBundle(string title)
        {
            Title = title;
            this.TransitionTo(new AvailableState());
        }

        public ProductBundle(string title, ProductState state)
        {
            Title = title;
            this.TransitionTo(state);
        }

        public override void TransitionTo(ProductState state)
        {
            this.State = state;
            this.State.SetProduct(this);
            foreach (Product product in Products)
            {
                product.TransitionTo(state);
            }
        }

        // TODO: This is a hacky workaround

        public override void BorrowProduct()
        {
            this.TransitionTo(new BorrowedState());
        }

        public override void ReturnProduct()
        {
            this.TransitionTo(new AvailableState());
        }


        public override void Add(Product product)
        {
            Products.Add(product);
        }

        public override void Remove(Product product)
        {
            Products.Remove(product);
        }

        public int Length()
        {
            return Products.Count;
        }

        public override void PrintDetails(bool fullDetails)
        {
            Console.WriteLine($"Bundle Name: {Title}");

            foreach (Product product in Products)
            {
                product.PrintDetails(fullDetails);
            }
        }
    }
}
