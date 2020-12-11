using System;
using System.Collections.Generic;
using System.Linq;

namespace B2CPackageCollect
{
    public static class Check
    {
        public static void NotNull<T>(T value, string valueName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(valueName);
            }
        }

        public static void NotNull<T>(T value, string valueName, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(valueName, message);
            }
        }

        public static void NotNull<T>(T? value, string valueName)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(valueName);
            }
        }

        public static void NotNull<T>(T? value, string valueName, string message)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(valueName, message);
            }
        }

        public static void NotNullOrEmpty(string value, string valueName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"The string argument '{valueName}' cannot be null or empty.", valueName);
            }
        }

        public static void NotNullOrWhiteSpace(string value, string valueName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"The string argument '{valueName}' cannot be null,empty or space.", valueName);
            }
        }

        public static void GreaterThan<T>(T lowerLimit, T value, string valueName)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException(valueName);
            }
        }

        public static void GreaterThan<T>(T lowerLimit, T value, string valueName, string message)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException(valueName, message);
            }
        }

        public static void LessThan<T>(T upperLimit, T value, string valueName)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(valueName);
            }
        }

        public static void LessThan<T>(T upperLimit, T value, string valueName, string message)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(valueName, message);
            }
        }

        public static void NotUnique<T>(IEnumerable<T> value, string valueName)
        {
            var set = new HashSet<T>();
            if (value.Any(item => !set.Add(item)))
            {
                throw new ArgumentException("Values in the collection are not unique", valueName);
            }
        }

        public static void EnumDefined(Type enumType, object value, string valueName)
        {
            if (Enum.IsDefined(enumType, value) == false)
            {
                throw new ArgumentException($"The value provided '{valueName}' must be a valid value of enum type '{enumType}'", valueName);
            }
        }

        public static void HasItem<T>(IEnumerable<T> value, string valueName)
        {
            if (value == null)
            {
                throw new ArgumentException($"{valueName} null !");
            }

            if (!value.Any())
            {
                throw new ArgumentException($"{valueName} has not item");
            }
        }

        public static T IsTypeOf<T>(object obj)
            where T : class
        {
            if (obj == null)
            {
                throw new ArgumentException("Passing object is null", nameof(obj));
            }

            if (obj is T value)
            {
                return value;
            }

            throw new ArgumentException($"{obj.GetType().Name} is not an instance of type ,{typeof(T).Name}");
        }
    }
}
