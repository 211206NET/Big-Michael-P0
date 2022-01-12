using Models;
using StoreDL;

namespace StoreBL;
public interface IBL : IRepo
{
    List<Customer> GetAllCustomer();

    void newstore(Storefront newStore);

    List<Storefront> GetAllStores();

}