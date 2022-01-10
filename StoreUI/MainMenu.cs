using StoreDL;
using StoreBL;
namespace UI;

public static class Mainmenu{

    public static void Start(){

        string connectionString = File.ReadAllText("connectionString.txt");
        IRepo repo = new DBRepo(connectionString);
        IBL BL = new BL(repo);
        bool exit = false;

        while(!exit){

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Sign Up");
            Console.WriteLine("[2] Login");
            Console.WriteLine("[X] Exit");
            string? input = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(input))
            {
                switch (input)
                {
                    case "1":
                        // signup menu instantiation
                        //start
                        
                    break;
                    case "2":
                        //login menu
                        Login login = new Login();
                        login.start();
                        
                    break;
                    case "x":
                        exit = true;
                        Console.WriteLine("goodbye!");
                    break;

                }
            }
            else
            {
                Console.WriteLine("Please enter valid input");
            }
        }


    }
    
}