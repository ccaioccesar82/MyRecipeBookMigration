using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace MyRecipeBook.Infrastructure.Migrations
{
    public static class MigrateDatabase
    {

        //Criando um método para validar se já existe o database na máquina do servidor. Caso não tenha, será criado.
        public static void EnsureDatabaseIsCreated(string connectionString)
        {

            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);

            string dataBaseName = connectionStringBuilder.Database;

            connectionStringBuilder.Remove("Database");

            using MySqlConnection dbConnection = new MySqlConnection(connectionStringBuilder.ConnectionString);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("name", dataBaseName);

            IEnumerable<dynamic> records = dbConnection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", parameters);

            if (records.Any() == false)
            {
                dbConnection.Execute($"CREATE DATABASE {dataBaseName}");

            } 

        }
    }
}
