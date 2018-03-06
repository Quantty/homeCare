using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homecare.Database;
using System.Linq;

namespace Homecare.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext();
            IQueryable<Person> data = from p in dataContext.Persons select p;
            Assert.IsTrue(data.Count() > 1);
        }
    }
}
