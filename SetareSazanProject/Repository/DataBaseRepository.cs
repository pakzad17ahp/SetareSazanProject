using System.Data.SqlClient;

namespace SetareSazanProject.Repository
{
    public class DataBaseRepository
    {
        public static string ConnectionString;

        public static void Destory()
        {
            ConnectionString = null;
        }

        public DataBaseRepository(bool update = false)
        {
            if (ConnectionString == null || update)
                ConnectionString = Connection;
        }

        protected SqlConnection DBConnection => new SqlConnection(Connection);

        public string Connection =>
            DataAccess.DataBaseConnection.ReadConnection(DataAccess.DataBaseConnection.GetConnectFilePath());
    }
}