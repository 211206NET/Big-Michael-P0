using Models;
using Microsoft.Data.SqlClient;
//To get the above namespace working, run
//dotnet add package Microsoft.Data.Sqlclient
using System.Data;
namespace StoreDL;


public class DBRepo : IRepo
{
    private string _connectionString;
    public DBRepo(string connectionString) {
        _connectionString = connectionString;
    }

    public Customer AddCustomer(Customer customerinfo)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAllCustomer()
    {
        using(SqlConnection connection = new SqlConnection(_connectionString)
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection));


        }
            return 1;
    }
}