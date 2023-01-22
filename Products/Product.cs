using LibraryApp.Products.ProductFSM;

namespace LibraryApp.Products
{
    public abstract class Product
    {
        protected ProductState State;

        public string Title { get; protected set; }
        //protected DateTime? releaseDate;
        //protected string creator;
        //protected string publisher;

        public virtual void TransitionTo(ProductState state)
        {
            this.State = state;
            this.State.SetProduct(this);
        }

        public string BorrowProduct()
        {
            return this.State.BorrowProduct();
        }

        public string ReturnProduct()
        {
            return this.State.ReturnProduct();
        }

        public abstract void PrintDetails();

        public ProductState GetProductState()
        {
            return this.State;
        }


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
