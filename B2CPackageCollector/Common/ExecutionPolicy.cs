using System;
using System.Data.SqlClient;
using System.IO;
using Polly;
using Polly.Retry;

namespace B2CPackageCollect
{
    public static class ExecutionPolicy
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ExecutionPolicy()
        { }

        public static readonly TimeSpan[] RetryDurations =
        {
            TimeSpan.FromMilliseconds(100),
            TimeSpan.FromMilliseconds(250),
            TimeSpan.FromMilliseconds(650)
        };

        public static readonly RetryPolicy RetryOnSqlException = Policy.Handle<SqlException>(SqlExceptionSpecification.CanRetry).WaitAndRetry(RetryDurations);
        public static readonly RetryPolicy RetryOnIoException = Policy.Handle<IOException>().WaitAndRetry(RetryDurations);
    }
}
