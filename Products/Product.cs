using LibraryApp.Products.ProductFSM;

namespace LibraryApp.Products
{
    public abstract class Product
    {
        protected ProductState state;

        public string Title { get; protected set; }
        //protected DateTime? releaseDate;
        //protected string creator;
        //protected string publisher;

        public virtual void transitionTo(ProductState state)
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


        public virtual void Add(Product product)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
