using System;
using System.Threading.Tasks;
using MySqlConnector;

namespace dbcontext {
    internal class DBConnect {

        class MySqlRead {
            static async Task Main(string[] args) {
                var builder = new MySqlConnectionStringBuilder {
                    Server = "yc2302sql.mysql.database.azure.com",
                    Database = "yc2302",
                    UserID = "yc2302",
                    Password = "Water123",
                    SslMode = MySqlSslMode.Required,
                };

                using (var conn = new MySqlConnection(builder.ConnectionString)) {
                    Console.WriteLine("Opening connection");
                    await conn.OpenAsync();

                    using (var command = conn.CreateCommand()) {
                        command.CommandText = "SELECT * FROM rooster;";

                        using (var reader = await command.ExecuteReaderAsync()) {
                            while (await reader.ReadAsync()) {
                                Console.WriteLine(string.Format(
                                    "Reading from table=({0}, {1}, {2})",
                                    reader.GetInt32(0),
                                    reader.GetDateTime(1),
                                    reader.GetDateTime(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetString(5),
                                    reader.GetString(6),
                                    reader.GetString(7)
                                    ));
                            }
                        }
                    }

                    Console.WriteLine("Closing connection");
                }

                Console.WriteLine("Press RETURN to exit");
                Console.ReadLine();
            }
        }
    }
}
