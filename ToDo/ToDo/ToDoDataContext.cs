using MySql.Data.MySqlClient;

namespace ToDo;

internal static class DB
{
    public static ToDoDataContext I { get; set; }
}

// Note: Paused Android while working out how to use SQLite - this is since using MySQL would be easiest with a web service running on the MySQL server to run queries through
internal class ToDoDataContext
{
#if !__MOBILE__
    private const string _connectionString = "Server=127.0.0.1;Database=local_todo;User ID=todo;Password=todo;";
    private MySqlConnection _conn;
#endif
#if __MOBILE__
    // Skipped since I have trouble with Android 13 File Access
    //private string _connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "todow.sqlite");
    //private SQLiteConnection _conn;
    private List<ToDo.Models.ToDo> ToDos { get; set; }
#endif

    public ToDoDataContext()
    {
        DB.I = this;

#if !__MOBILE__
        _conn = new MySqlConnection(_connectionString);
        _conn.Open();
#endif
#if __ANDROID__
        // This will only check if the permission is granted but will not prompt the user.
        //bool isGranted = Windows.Extensions.PermissionsHelper.CheckPermission(ct, Android.Manifest.Permission.RecordAudio); // await?

        // This will prompt the user with the native permission dialog if needed. If already granted it will simply return true.
        //bool isPermissionGranted = Windows.Extensions.PermissionsHelper.TryGetPermission(ct, Android.Manifest.Permission.RecordAudio); // await?
#endif
#if __MOBILE__
        // Skipped since I have trouble with Android 13 File Access
        //if (!File.Exists(_connectionString)) File.Create(_connectionString);
        //_conn = new SQLiteConnection($"Data Source={_connectionString};");
        ////_conn.Open();
        //_conn.Execute("CREATE TABLE IF NOT EXISTS `todos` (  `id` int NOT NULL AUTO_INCREMENT,  `name` varchar(45) NOT NULL,  `completedon` varchar(32) DEFAULT NULL,  PRIMARY KEY (`id`),  UNIQUE KEY `id_UNIQUE` (`id`))");
        ToDos = new();
#endif
    }

    public List<Models.ToDo> GetToDos()
    {
        var answer = new List<Models.ToDo>();

        try
        {
#if !__MOBILE__
            using (var query = _conn.CreateCommand())
            {
                query.CommandText = "SELECT id, name, completedon FROM todos WHERE completedon IS NULL";
                using (var result = query.ExecuteReader())
                {
                    while (result.Read())
                    {
                        answer.Add(new()
                        {
                            id = result.GetInt32("id"),
                            name = result.GetString("name"),
                            completedon = null
                        });
                    }
                }
            }
#endif
#if __MOBILE__
            ToDos.ForEach(it => 
            {
                answer.Add(it);
            });
#endif
        }
        catch (Exception e)
        {
            var _break = 1;
        }

        return answer;
    }

    ~ToDoDataContext()
    {
#if !__MOBILE__
        _conn.Close();
#endif
    }

    //public void MakeBakup()
    //{
    //    string path = System.IO.Path.Combine("/storage/emulated/0/Download", $"TODO_BACKUP{DateTime.Now.ToString("_yyyyMMdd_HHmmss")}.sqlite");
    //    File.Copy(_dbPath, path);
    //}
}