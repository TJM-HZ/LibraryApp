using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    abstract class ProductState
    {
        protected Product product;

        public void setProduct(Product product)
        {
            this.product = product;
        }

        public abstract void borrowProduct();
        public abstract void returnProduct();
    }
}
