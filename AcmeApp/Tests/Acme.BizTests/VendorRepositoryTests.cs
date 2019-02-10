using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetriveValueTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = 42;

            //Act
            var actual = repository.RetriveValue<int>("Select ...", 42);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void RetriveValueStringTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = "Test";

            //Act
            var actual = repository.RetriveValue<string>("Select ...", "Test");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void RetriveValueObjectTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //Act
            var actual = repository.RetriveValue<Vendor>("Select ...", vendor);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}