using System;
using LensDotNet.Core.Queries;

namespace LensDotNet.CoreTests
{
	public class ArgumentBuilderTests
	{
		[Test]
		public void ShouldBuildDictionaryFromSimpleObject()
		{
			var dict = ArgumentBuilder.BuildDictionary(new { Name = "Man", LastName = "From Earth" });
			Assert.That(dict, Is.Not.Null);
            Assert.That(dict.Keys.Count, Is.EqualTo(2));
			Assert.That(dict, Contains.Key("name"));
            Assert.That(dict, Contains.Key("lastName"));
			Assert.That(dict["name"], Is.EqualTo("Man"));
			Assert.That(dict["lastName"], Is.EqualTo("From Earth"));
        }

        record Test(string? Name, string? LastName);

        [Test]
        public void ShouldSkipNullValues()
        {
            
            var dict = ArgumentBuilder.BuildDictionary(new Test(null,"From Earth"));
            Assert.That(dict, Is.Not.Null);
            Assert.That(dict.Keys.Count, Is.EqualTo(1));
            Assert.That(dict, Does.Not.ContainKey("name"));
            Assert.That(dict, Contains.Key("lastName"));
            Assert.That(dict["lastName"], Is.EqualTo("From Earth"));
        }

        [Test]
        public void ShouldGetDefaultPropertyNamesFromRecord()
        {

            var dict = ArgumentBuilder.GetDefaultFieldNames(new Test("The Man", "From Earth").GetType());
            Assert.That(dict, Is.Not.Null);
            Assert.That(dict.Count(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldGetDefaultPropertyNamesFromGenericType()
        {
            var dict = ArgumentBuilder.GetDefaultFieldNames(new { Name = "The Man", LastName = "From Earth" }.GetType());
            Assert.That(dict, Is.Not.Null);
            Assert.That(dict.Count(), Is.EqualTo(2));
        }
    }
}

