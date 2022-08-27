using System.Data.SqlClient;

namespace CustomerDatalayer.Repositories
{
    public class BaseRepository
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Server=localhost;Database=CustomerLib_Tolstykh;Trusted_Connection=True;");
        }
    }
}
