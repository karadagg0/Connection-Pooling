using System.Data.SqlClient;

const string connStr = "";
const string connStr2 = "";
await ConnectionCountWithCloseConn();
//await ConnectionCountWithoutCloseConn();
//await ConnectionPooling();
Console.ReadLine();

async Task ConnectionPooling()
{
    for(int i = 0; i <3; i++)
    {
        await ConnectAsync(connStr);
    }
    for (int i = 0; i <3; i++)
    {
        await ConnectAsync(connStr2);
    }
    //SqlConnection.ClearAllPools();
}

async Task ConnectionCountWithoutCloseConn()
{
    SqlConnection.ClearAllPools();
    for(int i = 0; i < 10; i++)
    {
        try
        {
           
            using var connection = new SqlConnection(connStr);
            await connection.OpenAsync();
            await Task.Delay(100);
            throw new TimeoutException();
            connection.Close();
        }
        catch (TimeoutException exception)
        {

        }
    }
}

async Task ConnectionCountWithCloseConn()
{
    for (int i = 0; i < 10; i++)
    {
        try
        {
            using var connection = new SqlConnection(connStr);
            await connection.OpenAsync();
            await Task.Delay(100);
            throw new TimeoutException();
            connection.Close();
        }
        catch (TimeoutException exception)
        {

        }
    }
}
async Task ConnectAsync(string connectionString)
{
    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();

    //SqlConnection.ClearPool(connection);
    await Task.Delay(1500);
}






