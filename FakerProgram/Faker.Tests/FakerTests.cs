using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLibrary;
using FakerProgram;
using System.Collections.Generic;

namespace FakerTest.Tests
{
    [TestClass]
    public class FakerTests
    {
        private Foo foo;

        [TestInitialize]
        public void Init()
        {
            Faker faker = new Faker();
            foo = faker.Create<Foo>();
        }

        [TestMethod]
        public void ClassNameTest()
        {
            Assert.IsTrue(foo is Foo);
        }

        [TestMethod]
        public void Int32IsSet()
        {
            Assert.IsTrue(foo.IntValue is Int32 && foo.IntValue > Int32.MinValue && foo.IntValue < Int32.MaxValue);
        }

        [TestMethod]
        public void StringIsSet()
        {
            Assert.IsTrue(foo.StringValue is String && foo.StringValue != null && foo.StringValue != "");
        }

        [TestMethod]
        public void Int64IsSet()
        {
            Assert.IsTrue(foo.LongValue is Int64 && foo.LongValue > Int64.MinValue && foo.LongValue < Int64.MaxValue);
        }

        [TestMethod]
        public void DoubleIsSet()
        {
            Assert.IsTrue(foo.DoubleValue is Double && foo.DoubleValue > Double.MinValue && foo.DoubleValue < Double.MaxValue);
        }

        [TestMethod]
        public void ICollectionDateTimeIsSet()
        {
            Assert.IsTrue(foo.ICollectionValueDateTime is ICollection<DateTime>);
        }

        [TestMethod]
        public void FooValueIsSet()
        {
            Assert.IsTrue(foo.FooValue is Foo);
        }

        [TestMethod]
        public void BarValueIsSet()
        {
            Assert.IsTrue(foo.BarValue is Bar);
        }

        [TestMethod]
        public void BarIsSetFloatValue()
        {
            Assert.IsTrue(foo.BarValue.Int64Value is Int64 &&
                foo.BarValue.Int64Value > Int64.MinValue &&
                foo.BarValue.Int64Value < Int64.MaxValue);
        }

        [TestMethod]
        public void FooReferenceIsSet()
        {
            Assert.IsTrue(foo.BarValue.FooValue is Foo &&
                foo.BarValue.FooValue == foo.FooValue);
        }

    }
}
