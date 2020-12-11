using System;
using System.Threading;

namespace B2CPackageCollect
{
    public class SquentialGuid
    {
        private static readonly long BaseTicks;
        private static long _increment;

        static SquentialGuid() => BaseTicks = new DateTime(1900, 1, 1).ToUniversalTime().Ticks;

        public static Guid NewGuid()
        {
            Interlocked.Add(ref _increment, 2);
            var guidArray = Guid.NewGuid().ToByteArray();
            var now = DateTime.UtcNow;
            var days = new TimeSpan(now.Ticks - BaseTicks);
            var mSecs = now.TimeOfDay;
            var daysArray = BitConverter.GetBytes(days.Days);
            // Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333 
            var millisecondsArray = BitConverter.GetBytes((long)((mSecs.TotalMilliseconds + Interlocked.Read(ref _increment)) / 3.333333));

            // Reverse the bytes to match SQL Servers ordering 
            Array.Reverse(daysArray);
            Array.Reverse(millisecondsArray);

            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(millisecondsArray, millisecondsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }
    }
}
