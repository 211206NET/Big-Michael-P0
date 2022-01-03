namespace UI;


public class Login{
    public void start(){
        
        Console.WriteLine("Please enter user ID");
        //figure out parse vs convert int
        int UserId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please input password");
        string? Password = Console.ReadLine();

        // need DL stuff to check info
        Console.WriteLine("Glad to have you!");
        CustomerMenu customerMenu = new CustomerMenu();
        customerMenu.start();


    }
}