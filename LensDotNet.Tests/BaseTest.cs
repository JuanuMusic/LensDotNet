using System;
using LensDotNet.Models;

namespace LensDotNet.Tests
{
	public class BaseTest
	{
        public LensContext Context;
        [SetUp]
        public virtual void SetUp() { Context = new LensContext(); }
	}
}

