using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Products.ProductFSM
{
    public abstract class ProductState
    {
        protected Product Product;

        public void SetProduct(Product product)
        {
            this.Product = product;
        }

        public abstract void BorrowProduct();
        public abstract void ReturnProduct();
    }
}
