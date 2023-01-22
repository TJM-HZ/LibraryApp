# LibraryApp
C# application created to demonstrate Builder, Singleton, Composite and State design patterns.
Note: The quotes code below does not contain _using_ statements. The quotes code may have some methods removed that are not particularly relevant to the design pattern in question.

### DISCLAIMER
- I worked on this project by myself, so that I had more freedom to study C# and the design patterns at my own pace.
- This app has been tested and compiled on Windows 10.
- Please DO NOT resize the console window, as doing so may impede the app’s operation.
- This app features a user interface that has yet to be finished. The design patterns discussed here have been implemented, but the relevant features may or may not be accessible through the user interface due to time constraints. For example, you can currently view and interact with pre-made bundles, but cannot make them yourself in the app.
- While using this app, you may encounter issues like certain lines not clearing properly or being able to enter values that shouldn’t realistically be allowed. These are, for the most part, known issues that could not be solved in time for the first hand-in opportunity.
- There is a subclass of Product called Film which was intended to be used in the final product but couldn’t be fully implemented due to a lack of time.
- I’m still relatively new to C# and its conventions, so the names of some fields may or may not follow convention. Apologies for the confusion.

This exercise is, first and foremost, about implementing a variety of design patterns.
In the interest of time, I prioritised the implementation of these design patterns over the program (and source code) being maintainable, clean or useful.

## DESIGN PATTERNS
### CREATIONAL PATTERNS
#### BUILDER
Books have a very long list of variables, many of which have been made optional in the event certain values are unknown or unnecessary. 
A book might not have an illustrator, for example.
This makes using a single constructor to create a Book difficult, as you may quickly lose track of what parameter you are entering. 
It also looks rather ugly, especially when you need to enter null a whole lot. And if you change the constructor of Book later down the line, you'll have to update all initializations of the Book. 
Using telescoping constructors is also a no-go: 
the number of constructors needed to account for every combination would quickly spiral out of control.

Instead of doing either of those things, I implemented a BookBuilder.
Many of the methods in BookBuilder would return the BookBuilder itself, which allows for method chaining, making the creation of new Books even easier.
This design pattern is interacted with most prominently when adding a new book in the app, where the user builds a book step-by-step.

_BookBuilder.cs_
```
namespace LibraryApp.Products.ProductBuilders
{
    public class BookBuilder
    {
        private string? _title;

        private ProductState? _state;

        private string? _author;
        private string? _illustrator;
        private string? _publisher;

        private string? _language;

        private string? _country;

        private int? _printLength;

        private string? _isbn10;
        private string? _isbn13;

        private BookBuilder() 
        { 
            this.Reset(); 
        }

        private static BookBuilder _instance;

        private static readonly object Lock = new object();

        public static BookBuilder GetInstance()
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BookBuilder();
                    }
                }
            }
            return _instance;
        }

        public BookBuilder Title(string title)
        {
            this._title = title;
            return this;
        }

        public BookBuilder State(ProductState state) {
            this._state = state;
            return this;        
        }

        public BookBuilder Author(string author)
        {
            this._author = author;
            return this;
        }
        public BookBuilder Illustrator(string illustrator)
        {
            this._illustrator = illustrator;
            return this;
        }

        public BookBuilder Publisher(string publisher)
        {
            this._publisher = publisher;
            return this;
        }

        public BookBuilder Language(string language)
        {
            this._language = language;
            return this;
        }

        public BookBuilder Country(string country)
        {
            this._country = country;
            return this;
        }

        public BookBuilder PrintLength(int printLength)
        {
            this._printLength = printLength;
            return this;
        }

        public BookBuilder Isbn10(string isbn10)
        {
            this._isbn10 = isbn10;
            return this;
        }

        public BookBuilder Isbn13(string isbn13)
        {
            this._isbn13 = isbn13;
            return this;
        }

        public void Reset()
        {
            this._title = null;
            this._author = null;
            this._state = null;
            this._illustrator = null;
            this._publisher=null;
            this._language = null;
            this._country = null;
            this._printLength = null;
            this._isbn10 = null;
            this._isbn13 = null;
        }

        public Book Build()
        {
            if(this._title== null)
            {
                this._title = "LIBRARY ERROR: NO TITLE FOUND";
            }
            Book result = new Book(this._title, this._state, this._author, this._illustrator, this._publisher, this._language, this._country, this._printLength, this._isbn10, this._isbn13);
            this.Reset();
            return result;
        }


    }
}
```

#### SINGLETON
The BookBuilder is a Singleton: there exists only one BookBuilder in the application.
The implementation is thread-safe, meaning that the class won’t behave incorrectly in a multithreaded environment. The specific implementation is called “double check lock”, wherein a lock object will synchronize threads upon first accessing the BookBuilder.
There is also a GlobalLibrary Singleton, containing Lists of all Products organized by category (i.e., Book and ProductBundle). 
This Singleton, too, is thread-safe, and can be accessed anywhere.

_GlobalLibrary.cs_
```
namespace LibraryApp
{
    public class GlobalLibrary
    {
        public List<Book> Books { get; private set; } = new List<Book>();
        public List<ProductBundle> Bundles { get; private set; } = new List<ProductBundle>();

        private static GlobalLibrary _instance;
        private static readonly object Lock = new object();

        public static GlobalLibrary GetInstance()
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new GlobalLibrary();
                    }
                }
            }
            return _instance;
        }

        // Methods for BOOKS
        public void addBook(Book book) { this.Books.Add(book); }

        public void removeBook(Book book) { this.Books.Remove(book); }


        // Methods for BUNDLES
        public void addBundle(ProductBundle bundle) { this.Bundles.Add(bundle); }

        public void removeBundle(ProductBundle bundle) { this.Bundles.Remove(bundle); }
    }
}
```

### STRUCTURAL PATTERNS
#### COMPOSITE
Books (and other potentially other Products like Films, although this feature could not be finished on time) can be bundled together in ProductBundles. ProductBundle inherits and overrides methods from Product, where a call to a “Product method” in ProductBundle, such as BorrowProduct() or ReturnProduct(), will in turn call methods of the same name in the underlying Products.
This means that an entire bundle of products can be lent out or returned and the information of all Products in a ProductBundle can be displayed at once.
In this implementation of the Composite pattern, ProductBundles act as composites, with the underlying Products (except ProductBundles, of course) acting as leaves.

_ProductBundle.cs_
```
namespace LibraryApp.Products.ProductTypes
{
    public class ProductBundle : Product
    {
        protected List<Product> Products = new List<Product>();

        public ProductBundle(string title)
        {
            Title = title;
            this.TransitionTo(new AvailableState());
        }

        public ProductBundle(string title, ProductState state)
        {
            Title = title;
            this.TransitionTo(state);
        }

        public override void TransitionTo(ProductState state)
        {
            this.State = state;
            this.State.SetProduct(this);
            foreach (Product product in Products)
            {
                product.TransitionTo(state);
            }
        }

        public override void Add(Product product)
        {
            Products.Add(product);
        }

        public override void Remove(Product product)
        {
            Products.Remove(product);
        }

        public override void PrintDetails(bool fullDetails)
        {
            Console.WriteLine($"Bundle Name: {Title}");

            foreach (Product product in Products)
            {
                product.PrintDetails(fullDetails);
            }
        }
    }
```

### BEHAVIORAL
#### STATE
The state pattern is used twice in the app:
- Firstly, there are concrete subclasses of ProductState, which determine the current state of a product (Available, Borrowed). 
A Product also has public methods for certain actions, like borrowing or returning a Product. Such a method will, when called, in turn call a similarly-named method in the current state of the Product, and the logic in that method takes it from there.
- Secondly, the Screen system appears to implement somewhat of a state pattern:
An App object acts as the context and has a public method that allows for the switching to and running of different Screens. The different concrete Screens act as states and are derived from an abstract Screens class. Side note: The constructor of some concrete Screens can take additional arguments. For example, BookViewScreen, which is used to display the details of a given book, takes a Book as an argument, to specify which Book is to be shows. Almost all Screens can also be passed a "previous screen" to be used when selecting the "Back" menu option.

EXAMPLE 1:
_Product.cs_
```
namespace LibraryApp.Products
{
    public abstract class Product
    {
        public ProductState State { get; protected set; }

        public string Title { get; protected set; }

        public virtual void TransitionTo(ProductState state)
        {
            this.State = state;
            this.State.SetProduct(this);
        }

        public virtual void BorrowProduct()
        {
            this.State.BorrowProduct();
        }

        public virtual void ReturnProduct()
        {
            this.State.ReturnProduct();
        }
    }
}
```
_State.cs_
```
namespace LibraryApp.Products.ProductFSM
{
    public abstract class ProductState
    {
        protected Product Product;
        public String StateName { get; protected set; }
        public void SetProduct(Product product)
        {
            this.Product = product;
        }

        public abstract void BorrowProduct();
        public abstract void ReturnProduct();
    }
}
```

EXAMPLE 2:

_App.cs_
```
namespace LibraryApp
{
    class App
    {
        private Screen _currentScreen;
        public App()
        {
            ChangeScreen(new HomeScreen(this));
        }

        public void ChangeScreen(Screen screen)
        {
            _currentScreen = screen;
            _currentScreen.Run();
        }
    }
}
```
_Screen.cs_
```
namespace LibraryApp.Screens
{
    abstract class Screen
    {
        protected App App;
        protected Screen PreviousScreen;

        public Screen(App app)
        {
            App = app;
            PreviousScreen = null;
        }

        public Screen(App app, Screen previousScreen)
        {
            App = app;
            PreviousScreen = previousScreen;
        }

        virtual public void Run()
        {
            // Runs the logic of the screen
        }
    }
}
```
_BookHubScreen.cs_
```
namespace LibraryApp.Screens.BookScreens
{
    class BookHubScreen : Screen
    {
        public BookHubScreen(App app, Screen previousScreen) : base(app, previousScreen) { }

        public override void Run()
        {
            Console.Clear();
            string[] options = { "Add New Book", "View All Books", "Back" };
            OptionMenu optionMenu = new OptionMenu(options);
            int selectedIndex = optionMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    App.ChangeScreen(new BookCreationScreen(App, this));
                    break;
                case 1:
                    App.ChangeScreen(new BookIndexScreen(App, this));
                    break;
                case 2:
                    App.ChangeScreen(PreviousScreen);
                    break;
            }

        }
    }
}
```



