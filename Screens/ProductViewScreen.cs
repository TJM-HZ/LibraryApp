using LibraryApp.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens
{
    internal class ProductViewScreen : Screen
    {
        private Product _product;

        public ProductViewScreen(App app, Product product) : base(app)
        {
            _product = product;
        }

        public void setProduct(Product product)
        {
            _product = product;
        }

        public override void Run()
        {
            _product.PrintDetails();
        }
    }
}
