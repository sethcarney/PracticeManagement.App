using Microsoft.Data.SqlClient;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;

namespace PracticeManagement.API.Database
{
    public class MsSqlContext
    {
        private MsSqlContext()
        {
            connectionString = "Server=DESKTOP-JVIQNQJ;Database=PracticeManagement_DB;Trusted_Connection=True;TrustServerCertificate=True";
        }

        private string connectionString;

        public List<Client> Get()
        {
            var results = new List<Client>();
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "select Id, Name, Notes, isActive  from Clients";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new Client
                        {
                            Id = (int)reader[0],
                            Name = reader[1]?.ToString() ?? string.Empty,
                            Notes = reader[2]?.ToString() ?? string.Empty,
                            isActive = Convert.ToBoolean(reader[3])
                        });
                    }
                }
            }

            return results;
        }

        public Client Get(int id)
        {
              var result = new Client();
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "select Id, Name, Notes, isActive  from Clients where Id = @Id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = new Client
                        {
                            Id = (int)reader[0],
                            Name = reader[1]?.ToString() ?? string.Empty,
                            Notes = reader[2]?.ToString() ?? string.Empty,
                            isActive = Convert.ToBoolean(reader[3])
                        };
                    }
                }
            }

            return result;  
        }

        public int insertClient(Client client)
        {
            int result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "insert into Clients (Name, Notes, isActive, OpenDate) values (@Name, @Notes, @isActive, @OpenDate); SELECT SCOPE_IDENTITY();";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@Notes", client.Notes);
                    cmd.Parameters.AddWithValue("@isActive", client.isActive);
                    cmd.Parameters.AddWithValue("@OpenDate", DateTime.Now);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return result;
        }

        public int deleteClient(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "delete from Clients where Id = @Id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Client> filterClients(SearchObj searchObj)
        {
            var results = new List<Client>();
            string sql = "select Id, Name, Notes, isActive  from Clients";
            foreach (var filterItem in searchObj.Filters)
            {
                if (filterItem.Name == "Show Closed" && filterItem.Applied == false)
                    sql = "select Id, Name, Notes, isActive  from Clients where isActive = 1"; 
                else
                    sql = "select Id, Name, Notes, isActive  from Clients where isActive = 0";
            }
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new Client
                        {
                            Id = (int)reader[0],
                            Name = reader[1]?.ToString() ?? string.Empty,
                            Notes = reader[2]?.ToString() ?? string.Empty,
                            isActive = Convert.ToBoolean(reader[3])
                        });
                    }
                }
            }

            return results;


        }

        private static MsSqlContext? instance;
        public static MsSqlContext Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new MsSqlContext();
                }
                return instance;
            }
        }
    }
}
