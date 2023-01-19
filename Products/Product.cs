using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Products.ProductFSM;

namespace LibraryApp.Products
{
    public abstract class Product
    {
        protected ProductState state;

        public string? Title { get; protected set; }
        //protected DateTime? releaseDate;
        //protected string creator;
        //protected string publisher;

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

        public abstract void printDetails();
    }
}
