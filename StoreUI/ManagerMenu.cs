using Models;
using StoreBL;
using StoreDL;
namespace UI;


public class ManagerMenu{

    private IBL _bl;
    public ManagerMenu(IBL bl)
    {
        _bl = bl;
    }
    
    
    public void Start()
    {
        bool exit = false;
        Console.WriteLine("Welcome to Restaurant Reviews!");
        while(!exit){

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Create new store");
            Console.WriteLine("[2] View/ Edit inventory");
            Console.WriteLine("[X] Exit");
            string? input = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(input))
            {
                switch (input)
                {
                    case "1":
                        //add store
                        Console.WriteLine("Store Address:");
                        string? address = Console.ReadLine();
                        Storefront newStore = new Storefront{
                            Address= address??""
                        };
                    _bl.newstore(newStore);   
                    break;
                    case "2":
                        //inventory menu
                        List<Storefront> allstore = _bl.GetAllStores();
                        
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
