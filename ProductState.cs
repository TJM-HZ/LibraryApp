using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    abstract class ProductState
    {
        protected Product product;

        public ProductState(Product product)
        {
            this.product = product;
        }

        public abstract void borrowProduct();
        public abstract void returnProduct();
        public abstract void damageProduct();
        public abstract void repairProduct();
    }
}
