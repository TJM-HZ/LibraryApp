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
        private ProductState state;
    

        public void changeState(ProductState state)
        {
            this.state = state;
        }
    
    
    }
}
