using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp44
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Data Source = DESKTOP-2J3MN6S; Initial Catalog = Products; Trusted_Connection=True; TrustServerCertificate = True";
            
            Task task1 = GetDataAsync(connectionString, "SELECT * FROM Tes2");
           
            Task task2 = GetDataAsync(connectionString, "SELECT * FROM Test");
            
            await Task.WhenAll(task1, task2);
            

        }
        static async Task GetDataAsync(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.WriteLine(reader[1]);
                }
            }
        }
    }
}