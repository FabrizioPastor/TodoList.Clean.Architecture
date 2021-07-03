using MySql.Data.MySqlClient;

namespace TodoList.ToDosItems.Shared.Infraestrucutre.Persistence.Dapper
{
    public class MySqlConnectionDb
    {
        private static MySqlConnectionDb _instance;
        public MySqlConnection Connection { get; }

        private MySqlConnectionDb()
        {
            Connection = new MySqlConnection("Server=localhost;" +
                                             "Database=todo_list_application;" +
                                             "Uid=root;" +
                                             "Pwd=*Saass_2021@mySQL*;");
        }

        public static MySqlConnectionDb GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MySqlConnectionDb();
            }
            return _instance;
        }
    }
}