using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public static class Queries
    {
        public static string? GetQueryFromResource(string resourcePath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string? retVal = null;
            using (Stream? stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        retVal = reader.ReadToEnd();
                    }
                }
                else
                {
                    throw new KeyNotFoundException("Could not find embbeded resource " + resourcePath);
                }
            }

            return retVal;
        }
    }
}
