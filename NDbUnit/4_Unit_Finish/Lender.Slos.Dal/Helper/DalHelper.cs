namespace Lender.Slos.Dal.Helper
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    internal class DalHelper
    {
        private readonly string _connectionString;

        public DalHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataSet ExecuteStoredProcedure(
            string procedureName, 
            IEnumerable<SqlParameter> parameters)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var dataSet = new DataSet();

                var command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                sqlConnection.Open();

                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                command.Parameters.Clear();

                return dataSet;
            }
        }

        public int ExecuteStoredProcedureNonQuery(
            string procedureName,
            IEnumerable<SqlParameter> parameters)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                sqlConnection.Open();

                var rowsAffected = command.ExecuteNonQuery();
                command.Parameters.Clear();

                return rowsAffected;
            }
        }
    }
}