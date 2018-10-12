using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLibrary;
using FakerProgram;
using Generators;
using System.Collections.Generic;

namespace FakerTest.Tests
{
    [TestClass]
    public class FakerTests
    {
        private Dictionary<Type, IGenerator> generators;
        private Faker faker;
        Foo foo;

        [TestInitialize]
        public void Init()
        {
            faker = new Faker();
            foo = faker.Create<Foo>();
            generators = new Dictionary<Type, IGenerator>();
            //faker.GetGenerators("Plugins.dll");
        }

        [TestMethod]
        public void ClassNameTest()
        {
            Assert.IsTrue(foo is Foo);
        }
    }
}
