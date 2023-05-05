using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LensDotNet.Core
{
    /// <summary>
    /// This is a base class for implementing strings as enums (or other objects).
    /// Complex enums (such as <see cref="Networks"/> inherit from this.
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        public string Value { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string value) => (Id, Value) = (id, value);

        public override string ToString() => Value;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Enumeration))
                return false;

            Enumeration otherValue = (Enumeration)obj;

           var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

        // Other utility methods ...
    }
}

