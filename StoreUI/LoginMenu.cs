using Models;
using StoreBL;
using StoreDL;
namespace UI;


public class Login{

    private IBL _bl;

    public Login(IBL bl)
    {
        _bl = bl;
    }
    
    
    public void Start()
    {
        List<Customer> allusers = _bl.GetAllCustomer();
        Console.WriteLine("Username: ");
        string username = Console.ReadLine() ??"";
        Console.WriteLine("Password: ");
        string password = Console.ReadLine() ??"";
        Customer login = new Customer
            {
                UserName = username ??"",
                Password = password ??"",
            };
        bool possibleUsername = allusers.Exists(x => x.UserName == login.UserName);
        bool possiblePassword = allusers.Exists(x => x.Password == login.Password);
        if (possiblePassword && possibleUsername)
        {
            Console.WriteLine($"Welcome back, {login.UserName}");
            
        }
        else
        {
            Console.WriteLine("Invalid Username or password");
            Mainmenu.Start();
        }
    }
}