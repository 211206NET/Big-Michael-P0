using Microsoft.Data.SqlClient;
using System.Data;
namespace Models;

public class Customer
{
    public Customer(){}
    public Customer(DataRow row){
        Email = row["Email"].ToString() ??"";
        Password = row["Password"].ToString() ??"" ;
    }
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
}