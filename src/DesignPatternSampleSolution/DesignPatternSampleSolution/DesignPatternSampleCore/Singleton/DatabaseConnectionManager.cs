using System.Configuration;
using System.Data.SqlClient;

namespace DesignPatternSampleCore.Singleton
{
    public sealed class DatabaseConnectionManager
    {
        private static readonly DatabaseConnectionManager _instance = new DatabaseConnectionManager();
        private readonly string _connectionString;

        // private コンストラクタ
        private DatabaseConnectionManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EmployeeDb"].ConnectionString;
        }

        // 唯一のインスタンスを返すプロパティ
        public static DatabaseConnectionManager Instance
        {
            get { return _instance; }
        }

        // SqlConnection を返すメソッド
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
