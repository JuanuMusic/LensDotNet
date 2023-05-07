using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Core.Adapters
{
    public static class QueryCompiler
    {
        public static string CompileResource(string resourcePath, Assembly? assembly = null)
        {
            if(assembly == null) assembly = Assembly.GetCallingAssembly();

            var query = CompileQuery(GetQueryFromResource(assembly, resourcePath), assembly);
            return query;
        }

        public static string CompileQuery(string query, Assembly importsAssembly)
        {
            var compiledQuery = query;

            if (compiledQuery.Contains("@import"))
            {
                // get all import instances
                var imports = compiledQuery.Split(Environment.NewLine).Select((line, index) => new { line, index }).Where(l => l.line.StartsWith("@import"));
                foreach (var import in imports)
                {
                    var importResourcePath = import.line.Replace("@import", "").Trim();
                    var importedQuery = GetQueryFromResource(importsAssembly, importResourcePath);
                    if (importedQuery == null)
                        throw new Exception($"Could not import resource path {importResourcePath}");

                    compiledQuery = compiledQuery.Replace(import.line, CompileQuery(importedQuery, importsAssembly));
                }
            }

            return compiledQuery;
        }

        public static string? GetQueryFromResource(Assembly assembly, string resourcePath)
        {
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
