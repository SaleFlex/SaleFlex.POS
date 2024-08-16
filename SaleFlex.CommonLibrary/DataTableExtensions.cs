using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SaleFlex.CommonLibrary
{
    public static class DataTableExtensions
    {
        public static T ToModelItem<T>(this DataRow row) where T : new()
        {
            T item = new T();
            try
            {
                IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

                foreach (var property in properties)
                {
                    try
                    {
                        property.SetValue(item, row[property.Name], null);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            catch (Exception xException)
            {
                //xException.TraceError();
            }
            return item;
        }

        public static B ToDefiniteItem<A, B>(this List<A> input, IEnumerable<B> output) where B : new()
        {
            B item = new B();

            foreach (A i in input)
            {
                if (i.GetType() == typeof(long))
                {

                }
            }

            return item;
        }
    }
}
