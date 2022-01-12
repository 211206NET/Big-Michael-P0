using Models;
using StoreBL;
using StoreDL;
namespace UI;


public class Signup{
    public void start(){
        
        Console.WriteLine("Please enter your UserName:");
        string input = Console.ReadLine() ?? "";
        Console.WriteLine("Please input password:");
        string Password = Console.ReadLine() ??"";

        // need DL stuff to check info
        Console.WriteLine("Glad to have you!");
        CustomerMenu customerMenu = new CustomerMenu();
        customerMenu.start();

    Customer signup = new Customer{
        UserName = input,
        Password = Password,
    
    };
    
    string connectionstring = File.ReadAllText("connectionString.txt");
    Customer savedCustomer = new BL(new DBRepo(connectionstring)).AddCustomer(signup);
    // IRepo repo = new DBRepo;
    }
}

        // string connectionString = File.ReadAllText("connectionString.txt");
        // IRepo repo = new DBRepo(connectionString);