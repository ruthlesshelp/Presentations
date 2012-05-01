using System.Collections.Generic;
using System.Text;
using Tests.Unit.Lender.Slos.Database.Bases;
using Tests.Unit.Lender.Slos.Database.Helpers;

namespace Tests.Unit.Lender.Slos.Database.Views
{
    public class StudentsTestsContext
        : TestContextBase
    {
        public StudentsTestsContext()
            : base(typeof(DalHelper))
        {
        }

        public string CreateQuery(
            string viewName,
            IEnumerable<string> columnNames = null,
            string whereClause = null)
        {
            var query = new StringBuilder("SELECT ");

            if (columnNames != null)
            {
                var first = true;
                foreach (var col in columnNames)
                {
                    query.AppendFormat(" [{0}] ", col);

                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        query.Append(", ");
                    }
                }
            }
            else
            {
                query.Append("* ");
            }

            query.AppendFormat("FROM [dbo].[{0}] ", viewName);

            if (!string.IsNullOrEmpty(whereClause))
            {
                query.AppendFormat("WHERE {0}", whereClause);
            }

            return query.ToString();
        }
    }
}