﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Products.ProductFSM;

namespace LibraryApp.Products
{
    abstract class Product
    {
        private ProductState state;

        public Product(ProductState state) => this.transitionTo(state);

        public void transitionTo(ProductState state)
        {
            this.state = state;
            this.state.setProduct(this);
        }

        public void borrowProduct()
        {
            this.state.borrowProduct();
        }

        public void returnProduct()
        {
            this.state.returnProduct();
        }
    }
}
