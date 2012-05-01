namespace Lender.Slos.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using Entities;
    using Helper;

    public class IndividualDal
    {
        private readonly string _connectionString;

        public IndividualDal(string connectionString)
        {
            _connectionString = connectionString;
        }


        public IndividualEntity Retrieve(int id)
        {
            var sqlHelper = new DalHelper(_connectionString);

            var parameters =
                new List<SqlParameter>
                    {
                        new SqlParameter("Id", id),
                    };

            var dataSet = sqlHelper.ExecuteStoredProcedure(
                "dal_Individual_Retrieve",
                parameters);

            IndividualEntity entity = null;
            if (dataSet != null &&
                dataSet.Tables.Count > 0)
            {
                var table = dataSet.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    entity =
                        new IndividualEntity
                        {
                            Id = row.Field<int>("Id"),
                            LastName = row.Field<string>("LastName"),
                            FirstName = row.Field<string>("FirstName"),
                            MiddleName = row.Field<string>("MiddleName"),
                            Suffix = row.Field<string>("Suffix"),
                            DateOfBirth = row.Field<DateTime>("DateOfBirth"),
                        };

                    // Retrieve shouldn't return more than 1 row.
                    break;
                }
            }

            return entity;
        }
    }
}
