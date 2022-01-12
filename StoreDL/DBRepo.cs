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
        _connectionString = File.ReadAllText("connectionString.txt");
    }

    public Customer AddCustomer(Customer customerInfo)
    {
        DataSet userinfo = new DataSet();
        string selectCmd = "SELECT * FROM StoreUser WHERE Id = -1";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                
                dataAdapter.Fill(userinfo, "UserTable");

                DataTable userTable = userinfo.Tables["UserTable"];
                
                
                //Generate a new row with the Restaurant Table Schema
                DataRow newRow = userTable.NewRow();
                
                // customerInfo.ToDataRow(ref newRow);
                // Fill the new row with the new restaurant information
                newRow["UserName"] = customerInfo.UserName;
                newRow["Password"] = customerInfo.Password ?? "";

                //add the new row to our restaurantTable Rows
                userTable.Rows.Add(newRow);

                //We need to set which query to execute for changes
                //We need to set SqlDataAdapter.InsertCommand to let it know
                //How to insert the new records it sees in the restoTable
                //string insertCmd = $"INSERT INTO StoreUser (Email, Password) VALUES ('{customerInfo.Email}', '{customerInfo.Password}')";

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

                //We have to tell the data adapter how to insert records (it's not magic)
                //We can either generate this command by manually typing it out or using SqlCommandBuilder
                // dataAdapter.InsertCommand = new SqlCommand(insertCmd, connection);
                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
                
                //SqlDataAdapter.UpdateCommand (for your Put/Update operations)
                // dataAdapter.UpdateCommand = cmdBuilder.GetUpdateCommand();

                //SqlDataAdapter.DeleteCommand (for your Delete Operations)
                // dataAdapter.DeleteCommand = cmdBuilder.GetDeleteCommand();
                //Tell the dataAdapter to update the DB with changes
                dataAdapter.Update(userTable);

                return customerInfo;
            }
        }
    }

    

    public List<Customer> GetAllCustomer()
    {
        List<Customer> userinfo = new List<Customer>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = "SELECT * FROM StoreUser";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer uInfo = new Customer();
                        uInfo.UserName = reader.GetString(1);
                        uInfo.Password = reader.GetString(2);

                        userinfo.Add(uInfo);
                    }
                }
            }
            connection.Close();
        }
        return userinfo;


}
}
