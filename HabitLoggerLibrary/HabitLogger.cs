using Microsoft.Data.Sqlite;

namespace HabitLoggerLibrary;


// A wrapper class for the SqliteConnection class which connects
// to the Habit Logger data base.
//
// This class is only fitted for the HabitLogger Application. This will
// cause errors if two instances of this clas are made within the same scope.
// This class is not suited for multi-threaded uses.
//
// This class interacts with the database using raw sql statements which leaves
// it prone to sql injection. While this is a not big deal for this application,
// it is still something to be aware of.
public class HabitLoggerConnection : IDisposable
{
    private static string DatabaseFilePath { get; } = @"Data Source=habitlogger.db";

    private SqliteConnection Connection { get; }


    public HabitLoggerConnection()
    {
        Connection = new(DatabaseFilePath);
        Connection.Open();
        EnsureTablesExist();
    }

    private void EnsureTablesExist()
    {
        string createTable =
                @"CREATE TABLE IF NOT EXISTS DRINK_WATER {
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Date DATETIME,
                Quantity INTEGER
                }";

        ExecuteNonQuery(createTable);
    }

    public void CreateLog(int cupsOfWater)
    {
        string createLog =
            $@"INSERT INTO DRINK_WATER (Date, Quantity)
            VALUES (CURDATE(), '{cupsOfWater}')";

        ExecuteNonQuery(createLog);
    }


    public List<Tuple<int, DateTime, int>> GetAllLogs()
    {
        string getAllLogs =
            $@" SELECT * FROM DRINK_WATER";

        var command = new SqliteCommand(getAllLogs, Connection);
        var reader = command.ExecuteReader();

        var logs = new List<Tuple<int, DateTime, int>>();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            DateTime dt = reader.GetDateTime(1);
            int quantity = reader.GetInt32(2);
            logs.Add(Tuple.Create(id, dt, quantity));
        }
        return logs;
    }

    public void DeleteLog(int id)
    {
        string deleteLog =
            $@"DELETE DRINK_WATER 
            WHERE id = {id}";
        ExecuteNonQuery(deleteLog);
    }

    public void UpdateLog(int id, int cupsOfWater)
    {
        string updateLog =
            $@"UPDATE DRINK_WATER
            SET Quantity = {cupsOfWater}
            WHERE id = {id}";
        ExecuteNonQuery(updateLog);
    }

    private void ExecuteNonQuery(string updateLog)
    {
        var command = new SqliteCommand(updateLog, Connection);
        command.ExecuteNonQuery();
    }

    public void Dispose()
    {
        Connection.Dispose();
    }
}

