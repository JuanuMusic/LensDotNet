using System;
using System.Dynamic;

namespace LensDotNet.TestUnions
{
    public interface IUnion<T1,T2> : IDynamicMetaObjectProvider
        where T1 : DynamicObject
        where T2 : DynamicObject
    {

    }
}

