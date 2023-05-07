using LensDotNet.Core.Adapters;
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
        private static string? _fragments;
        public static string? Fragments
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_fragments))
                    _fragments = QueryCompiler.CompileResource("LensDotNet.Client.GQL.fragments.gql");
                return _fragments;
            }
        }
       
    }
}
