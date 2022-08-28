namespace Chapter7finalProject
{
    enum Userstatus
    {
        deleted=0,
        basic,
        vip
    }
    enum OrderStatus
    {
        Canceled=0,
        Active,
        Dellivered
    }
    enum deliveryStatus
    {
        Canceled=0,
        InStock,
        InTransit,
        AtPickpoint,
        Delivered
    }
    class Order<TDelivery, TProduct> where TDelivery : Delivery
    {
        public Order(int id)
        { this.id = id; }

        public Order(int id,Customer customer,Adress adress, TProduct product)
        {
            this.customer = customer;
             this.adress = adress;
            this.product = product; 
        }

        public int id;
        public Customer customer;
        public Employee manager;
        public Adress adress;
        public OrderStatus status; 
        public TDelivery delivery;
        public TProduct product;

        public void CheckWeight()
        { }
        public void CheckVolume()
        { }
        public void ChangeStatus()
        { }

    }

    abstract class User
    {

        int id;
        public string Login;
        //string password;    
        public string LastName;
        public string FirstName;
        int age;
        public int Age
        { get; set; }
       public  void add()
        { }
       public  void passwordreset()
        { }
        public User(int id,string Login, string FirstName, string LastName, int Age)
        {
            this.id=id;
            this.Login = Login;
            this.FirstName = FirstName;
            this.LastName = LastName; 
            this.Age = Age;
        }
    }
    class Customer: User
    {
        public Customer(int id, string Login, string FirstName, string LastName, int Age, string password, Userstatus status, Adress adress)
            : base(id, Login, FirstName, LastName, Age)
        {
            this.password = password;
            this.status = status;   
            this.adress = adress;
            this.age = Age;
        }
        private string password;
        public Userstatus status;
        private Adress adress;
        private int age;
        public int Age
        {
            get { return age; }
            set { if (value < 18)
                { Console.WriteLine("Error must be over 18") ; }
                else age = value; }
        }

        public  void add()
        {
            
        }
        public  void passwordreset()
        {
            
        }
        public void ChangeStatus(int id, Userstatus status)
        { }
    }
    class Employee: User
    {
        private string password;
        private Adress adress;
        Department department;
        private decimal Salary;
        
        Employee(int id, string Login, string FirstName, string LastName, int Age, string passwords, Adress adress, Department department, decimal Salary)
            : base(id, Login, FirstName, LastName, Age)
        {
            this.password = password;
            this.department=department;
            this.Age=Age;
            this.adress=adress;
            this.Salary = Salary;
        }
        public  void add()
        {

        }
        public  void passwordreset()
        {

        }
        
    }
    class Adress
    {
        int postalCode;
        string City;
        string Street;
        string Country;
        string HomeNumber;
        int flatnumber;

        public Adress(int postalCode, string City, string Street, string Country, string HomeNumber, int flatnumber)
        {
            this.postalCode = postalCode;
            this.City = City;
            this.Street = Street;
            this.Country = Country;
            this.HomeNumber = HomeNumber;
            this.flatnumber = flatnumber;

        }
        public void ChangeAdress()
        { }
    }
    class Department
    {
        int id;
        string DepartmentName;
        User chief;

        public Department(int id,string DepartmentName, User chief)
        {
            this.id = id;
            this.DepartmentName = DepartmentName;
            this.chief = chief;
        }
    }
    public abstract class Product
    {
        public int id;
        public string Name;
        public string Manufacturer;
        public string Description;
        public decimal Price;

        public Product(int id, string Name, string Manufacturer, string Description, decimal Price)
        {
            this.id=id; 
            this.Name = Name;
            this.Manufacturer=Manufacturer;
            this.Description=Description;
            this.Price=Price;
        }
    }
    public class Food: Product
    {
        DateTime ExpirationDate;

        public Food(int id, string Name, string Manufacturer, string Description, decimal Price,DateTime ExpirationDate)
            :base(id, Name, Manufacturer, Description, Price)
        {
            this.ExpirationDate = ExpirationDate; 
        }
    }
    public class Tools : Product
    {
        int Weight;
        bool isMetric;

        public Tools(int id, string Name, string Manufacturer, string Description, decimal Price, int Weight, bool isMetric) : base(id, Name, Manufacturer, Description, Price)
        {
            this.Weight=Weight;
            this.isMetric=isMetric;
        }
     }
    abstract class Delivery
    {
        Adress adress;
        deliveryStatus deliveryStatus;
        public Delivery(Adress adress)
        {
            this.adress = adress;
        }
        public void ChangeStatus()
        { }
        class HomeDelivery : Delivery
        {
            public HomeDelivery(Adress adress) : base(adress)
            { 
                this.adress=adress;
            }
            public static int maxWeight = 50;
            public static int maxVolume = 3;
            public Adress adress;


       
        }

        class PickPointDelivery : Delivery 
        {
            public PickPointDelivery(Adress adress) : base(adress)
            {
                this.adress = adress;
            }
            public static int maxWeight = 10;
            public static int maxVolume = 1;
            
        }

        class ShopDelivery : Delivery 
        {
            

            public ShopDelivery(Adress adress) : base(adress)
            {
            }
        }
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}