using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Products.ProductFSM;

namespace LibraryApp.Products
{
    abstract class Product
    {
        protected ProductState state;

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
