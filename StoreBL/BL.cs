using Models;
using StoreDL;
namespace StoreBL;
public class BL : IBL
{
    private IRepo _dl;

    public BL (IRepo repo)
    {
        _dl = repo;
    }

    public List<Customer> GetAllCustomer()
    {
        return _dl.GetAllCustomer();
    }

    public Customer AddCustomer(Customer signupinfo){
        return _dl.AddCustomer(signupinfo);
    }
}
