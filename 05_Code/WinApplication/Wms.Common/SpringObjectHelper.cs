using System;
using Spring.Context;
using Spring.Context.Support;

namespace ecWMS.Common
{
    public class SpringObjectHelper
    {
        public static T GetObject<T>()
        {
            Type t = typeof(T);
            IApplicationContext context = ContextRegistry.GetContext();
            T obj = (T)context.GetObject(t.FullName);
            return obj;
        }

        public static T GetObject<T>(string name)
        {
            IApplicationContext context = ContextRegistry.GetContext();
            T obj = (T)context.GetObject(name);
            return obj;
        }
    }
}
