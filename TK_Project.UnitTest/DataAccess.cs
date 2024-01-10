using System.Data;
using System.Data.SqlClient;
namespace TK_Project.UnitTest
{
    public class DataAccess
    {
        [Fact]
        public void ConnectionString_IsCorrect()
        {
            // Arrange
            string connectionString = "Server=DESKTOP-FE7T1JB;Database=e_commerce_tk;TrustServerCertificate=true;integrated security=true";
            bool result = false;
            // Act
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                        result = true;
                }
                catch
                {
                    result = false;
                }
                connection.Close();
            }
            // Assert
            Assert.True(result);
        }
    }
}
