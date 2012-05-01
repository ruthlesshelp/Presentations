﻿namespace Lender.Slos.Dal
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

        public int Create(IndividualEntity entity)
        {
            // Guard against invalid arguments.
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (entity.Id > 0)
            {
                throw new InvalidOperationException("Entity is invalid for Create, the Id must be 0.");
            }

            var sqlHelper = new DalHelper(_connectionString);

            var parameters =
                new List<SqlParameter>
                    {
                        new SqlParameter("LastName", entity.LastName),
                        new SqlParameter("FirstName", entity.FirstName),
                        new SqlParameter("MiddleName", entity.MiddleName),
                        new SqlParameter("Suffix", entity.Suffix),
                        new SqlParameter("DateOfBirth", entity.DateOfBirth),
                    };

            try
            {
                var dataSet = sqlHelper.ExecuteStoredProcedure(
                    "dal_Individual_Create",
                    parameters);

                // Returns createdId if a record was created.
                var createdId = default(int);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    var table = dataSet.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        createdId = row.Field<int>("Id");

                        // Retrieve returns the first record.
                        break;
                    }
                }

                return createdId;
            }
            catch (Exception exception)
            {
                // Throw an exception if the Id was not returned.
                throw new InvalidOperationException("Failed to create.", exception);
            }
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

        public void Update(IndividualEntity entity)
        {
            // Guard against invalid arguments.
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (entity.Id <= 0)
            {
                throw new InvalidOperationException("Entity is invalid for Update, the Id must be greater than 0.");
            }

            var sqlHelper = new DalHelper(_connectionString);

            var parameters =
                new List<SqlParameter>
                    {
                        new SqlParameter("Id", entity.Id),
                        new SqlParameter("LastName", entity.LastName),
                        new SqlParameter("FirstName", entity.FirstName),
                        new SqlParameter("MiddleName", entity.MiddleName),
                        new SqlParameter("Suffix", entity.Suffix),
                        new SqlParameter("DateOfBirth", entity.DateOfBirth),
                    };

            var rowsAffected = sqlHelper.ExecuteStoredProcedureNonQuery(
                "dal_Individual_Update",
                parameters);

            if (rowsAffected != 1)
            {
                throw new InvalidOperationException("Entity saving failed during Update.");
            }
        }

        public void Delete(IndividualEntity entity)
        {
            // Guard against invalid arguments.
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (entity.Id <= 0)
            {
                throw new InvalidOperationException("Entity is invalid for Update, the Id must be greater than 0.");
            }

            var sqlHelper = new DalHelper(_connectionString);

            var parameters =
                new List<SqlParameter>
                    {
                        new SqlParameter("Id", entity.Id),
                    };

            var rowsAffected = sqlHelper.ExecuteStoredProcedureNonQuery(
                "dal_Individual_Delete",
                parameters);

            if (rowsAffected != 1)
            {
                throw new InvalidOperationException("Entity saving failed during Update.");
            }
        }
    }
}
