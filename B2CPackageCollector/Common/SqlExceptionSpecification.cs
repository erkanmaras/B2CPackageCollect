using System.Data.SqlClient;
using System.Linq;

namespace B2CPackageCollect
{
    public class SqlExceptionSpecification
    {
        public static int RetryCount = 3;
        private static readonly int[] RetriableClasses = { 13, 17, 18, 19, 20, 21, 22, 24 };

        private SqlExceptionSpecification()
        {
        }

        public static bool CanRetry(SqlException sqlException)
        {
            Check.NotNull(sqlException, nameof(sqlException));

            //https://msdn.microsoft.com/en-us/library/ms164086%28v=sql.120%29.aspx
            for (var i = 0; i < sqlException.Errors.Count; i++)
            {
                if (CanRetry(sqlException.Errors[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanRetry(SqlError sqlError)
        {
            // Handle unknown errors with severity 21 or less. 22 or more
            // indicates a serious error that need to be manually fixed.
            // 24 indicates media errors. They're serious errors (that should
            // be also notified) but we may retry...
            return RetriableClasses.Contains(sqlError.Class);
        }
    }
}
