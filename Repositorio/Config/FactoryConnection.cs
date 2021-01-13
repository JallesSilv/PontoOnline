using System.Data;
using System.Data.SqlClient;

namespace Repositorio.Config
{
    public static class FactoryConnection
    {
        public static SqlConnection connection => new SqlConnection(new SqlConnectionStringBuilder()
        {
            DataSource = XConfig.DataSource,
            InitialCatalog = XConfig.InitialCatalog,
            UserID = XConfig.UserID,
            Password = XConfig.Password
        }.ConnectionString);

        public static SqlConnection ConnectionTable => 
            new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

        public static SqlCommand NewBanco()
        {
            var command = ConnectionTable.CreateCommand();
            if (command.Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
                return command;
            }
            return command;
        }

        public static SqlCommand NewCommand()
        {
            var command = connection.CreateCommand();
            if (command.Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
                return command;
            }
            return command;
        }

        public static void Liberar()
        {
            connection.Close();
        }
    }
}
