using Microsoft.Data.Sqlite;

namespace HabitLoggerLibrary;


// A wrapper class for the SqliteConnection class which connects
// to the Habit Logger data base.
//
// This class is only fitted for the HabitLogger Application. This will
// cause errors if two instances of this clas are made within the same scope.
// This class is not suited for multi-threaded uses.
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
        string createTable = @"CREATE TABLE IF NOT EXISTS DRINK_WATER {
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date DATETIME,
                            Quantity INTEGER
                            }";

        SqliteCommand command = new(createTable, Connection);
        command.ExecuteNonQuery();
    }

    public void CreateLog(int cupsOfWater)
    {
        throw new NotImplementedException();
    }


    public string GetLogs()
    {
        throw new NotImplementedException();
    }

    public void DeleteLog(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateLog()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Connection.Dispose();
    }
}

