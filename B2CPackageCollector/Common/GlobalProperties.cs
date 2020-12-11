using System.Collections.Generic;

namespace B2CPackageCollect
{

    public class GlobalProperties
    {
        private Dictionary<string, object> Properties { get; }

        public GlobalProperties() => Properties = new Dictionary<string, object>();

        public T Get<T>(string parameterName)
        {
            if (Properties.ContainsKey(parameterName))
            {
                return (T)Properties[parameterName];
            }

            return default(T);
        }

        public bool TryGet<T>(string parameterName, ref T outPut)
        {
            if (Properties.ContainsKey(parameterName))
            {
                outPut = (T)Properties[parameterName];
                return true;
            }
            return false;
        }

        public bool Exist(string parameterName)
        {
            return Properties.ContainsKey(parameterName);
        }

        public bool Add(string parameterName, object value)
        {
            if (!Exist(parameterName))
            {
                Properties.Add(parameterName, value);
                return true;
            }

            return false;
        }

        public void AddOrUpdate(string parameterName, object value)
        {
            if (!Add(parameterName, value))
            {
                Properties[parameterName] = value;
            }
        }
    }
}
