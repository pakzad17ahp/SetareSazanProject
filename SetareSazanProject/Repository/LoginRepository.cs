using Dapper;
using System.Data;
using System.Linq;

namespace SetareSazanProject.Repository
{
    public class LoginRepository : DataBaseRepository
    {
        public bool LoginCheck(string userName, string password)
        {
            try
            {
                var allowed = DBConnection.Query("User_Set", new
                { userName = userName, password = password }, commandType: CommandType.StoredProcedure);
                if (allowed.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
