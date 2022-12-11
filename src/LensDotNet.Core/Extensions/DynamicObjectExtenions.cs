using System;
using System.Dynamic;
using Newtonsoft.Json;

namespace LensDotNet.Core.Extensions
{
    public static class DynamicObjectExtenions
    {
        public static T As<T>(this DynamicObject obj)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
